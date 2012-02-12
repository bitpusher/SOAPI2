using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace SOAPI2.DocScraper
{
    [Serializable]
    public class TypeInfo
    {
        public string GenericType { get; set; }
        public bool IsEnum { get; set; }

        public List<FieldInfo> Fields { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        private string _source;
        public bool Inferred { get; set; }
        public string Name { get; set; }
        public Docs Docs { get; set; }
        public TypeInfo(Docs docs)
        {
            Docs = docs;
            Fields = new List<FieldInfo>();
        }

        public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;

            }
        }

        private void ParseOldStyle(HtmlDocument sourceDoc)
        {
            HtmlNode fieldsList;
            fieldsList = sourceDoc.DocumentNode.SelectSingleNode("//div[@id='discussion']/ul");
            if (fieldsList == null)
            {
                throw new Exception("could not find fields list for " + Type);
            }

            var fields = fieldsList.SelectNodes("li");
            if (fields == null || fields.Count == 0)
            {
                throw new Exception("error reading fields list for " + Type);
            }
            foreach (HtmlNode field in fields)
            {
                var typeList = field.SelectNodes("ul");
                if (typeList == null || typeList.Count != 1)
                {
                    throw new Exception("error reading fields list for " + Type + ".[TODO field name]");
                }

                HtmlNode typeNode = typeList[0];
                field.RemoveChild(typeNode);
                HtmlNode filterNode = field.SelectSingleNode("span");

                // #TODO: set default filter flag
                field.RemoveChild(filterNode);

                var fieldInfo = new FieldInfo();
                string fieldName = field.InnerText.Trim();
                fieldInfo.Name = fieldName;
                Fields.Add(fieldInfo);
                var typeDescriptors = typeNode.SelectNodes("li");
                if (typeDescriptors == null)
                {
                    throw new Exception("error reading type descriptors list for " + Type + ".[TODO field name]");
                }
                if (typeDescriptors.Count != 1)
                {

                    if (typeDescriptors.Count == 2)
                    {
                        if (!typeDescriptors[1].InnerText.Contains("unchanged in unsafe filters"))
                        {
                            throw new Exception("expected unsafe filters");
                        }
                        fieldInfo.UnchangedInUnsafeFilters = true;
                    }



                }

                if (!typeDescriptors[0].InnerHtml.Contains("href=\"/docs/types/"))
                {
                    fieldInfo.IsPrimitive = true;

                }
                string fieldType = typeDescriptors[0].InnerText;

                if (fieldType.Contains("an array of"))
                {
                    fieldInfo.IsArray = true;
                    fieldType = fieldType.Replace("an array of", "");
                }
                if (fieldType.Contains("one of"))
                {
                    fieldInfo.IsEnum = true;
                    fieldType = fieldType.Replace(", or ", ", ");
                    fieldType = fieldType.Replace("one of", "");



                }
                //







                if (fieldInfo.IsEnum)
                {
                    fieldInfo.EnumValues = fieldType;
                    fieldType = Type + " " + fieldName;

                }



                //// clean up repeated words ?


                fieldType = fieldType.Replace("-", " ");
                fieldType = fieldType.Replace("_", " ");
                fieldType = fieldType.Trim();

                Regex doubleWordPattern = new Regex("\\b(?<word>\\w+)\\s+(\\k<word>)\\b");
                var doubleWordPatternMatch = doubleWordPattern.Match(fieldType);
                if (doubleWordPatternMatch.Success)
                {
                    string word = doubleWordPatternMatch.Groups["word"].Value;
                    fieldType = doubleWordPattern.Replace(fieldType, word);
                }
                fieldType = fieldType.Replace(" ", "_").Replace("-", "_");
                fieldInfo.Type = fieldType;
                if (fieldInfo.IsEnum)
                {
                    var type = new TypeInfo(Docs);
                    type.Type = fieldType;
                    type.Name = fieldType;
                    type.IsEnum = true;
                    type.Inferred = true;
                    foreach (string item in fieldInfo.EnumValues.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        var f = new FieldInfo();
                        f.Type = "string";
                        f.Name = item.Trim();
                        type.Fields.Add(f);

                    }
                    this.Docs.Types.Add(type);
                }

                // #EDGE CASE
                if (fieldType == "the_type_found_in_type")
                {
                    GenericType = fieldType;
                    fieldInfo.IsPrimitive = false;
                }

            }
        }
        public void ParseSource()
        {

            if (this.Inferred)
            {
                return;
            }
            // get description
            this.Name = this.Type.Replace(" ", "_").Replace("-", "_");
            HtmlDocument sourceDoc = new HtmlDocument();
            sourceDoc.LoadHtml(_source);

            // <div id="discussion">
            var summaryNode = sourceDoc.DocumentNode.SelectSingleNode("//div[@id='discussion']");
            if (summaryNode == null)
            {
                throw new Exception("could not find summary node for " + Type);
            }
            Description = summaryNode.InnerText.Trim();
            HtmlNode fieldsList;



            if (this.Name == "response_wrapper")
            {
                // #EDGE CASE

                ParseOldStyle(sourceDoc);
            }
            else
            {
                // fields are now a table. grr....
                //<table class="type-field-list">
                fieldsList = sourceDoc.DocumentNode.SelectSingleNode("//table[@class='type-field-list']");
                if (fieldsList == null)
                {
                    throw new Exception("could not find fields list for " + Type);
                }

                var rows = fieldsList.SelectNodes("tr");

                FieldInfo fieldInfo = null;

                
                foreach (var row in rows)
                {
                    HtmlNode td = row.SelectNodes("td")[0];
                    if (string.IsNullOrEmpty(td.InnerHtml.Trim()))
                    {
                        // this is additional descriptor for current fields
                        //unchanged in unsafe filters
                        td = row.SelectNodes("td")[1];

                        // td is now the field type descriptor
                        if (td.InnerText.Trim() != "unchanged in unsafe filters")
                        {
                            throw new Exception("unexpected field type descriptor:" + td.InnerText.Trim());
                        }
                        fieldInfo.UnchangedInUnsafeFilters = true;
                    }
                    else
                    {
                        fieldInfo = new FieldInfo();
                        this.Fields.Add(fieldInfo);

                        // this is a new field
                        //<td><span class='included' title='this field is included in the default filter'>&acirc;&oelig;&rdquo;</span> question_id</td>
                        // <td>integer, refers to a <a href="/docs/types/question">question</a></td>
                        bool included = false;
                        var span = td.SelectSingleNode("span");
                        if (span == null)
                        {
                            throw new Exception("could not find include/exclude span");
                        }
                        var classAttr = span.Attributes["class"];
                        if (classAttr == null || (classAttr.Value != "included" && classAttr.Value != "excluded"))
                        {
                            throw new Exception("unexpected class in field row");
                        }

                        if (classAttr.Value == "included")
                        {
                            included = true;
                        }
                        fieldInfo.IncludedInDefaultFilter = included;
                        td.ChildNodes.Remove(span);
                        var fieldName = td.InnerText.Trim();
                        fieldInfo.Name = fieldName;

                        td = row.SelectNodes("td")[1];
                        // td is now the field type descriptor



                        // look for "xxx, refers to a question"

                        string fieldType = null;
                        if (td.InnerText.IndexOf(", refers to") > -1)
                        {
                            string description = td.InnerText.Substring(td.InnerText.IndexOf(", refers to") + 1).Trim();
                            fieldInfo.Description = description;

                            fieldType = td.InnerText.Substring(0, td.InnerText.IndexOf(", refers to")).Trim();

                        }
                        else
                        {
                            fieldType = td.InnerText;
                        }

                        string tdInnerHtml = td.InnerHtml;
                        if (tdInnerHtml.IndexOf(", refers to") > -1)
                        {
                            tdInnerHtml = tdInnerHtml.Substring(0, tdInnerHtml.IndexOf(", refers to")).Trim();
                        }

                        if (!tdInnerHtml.Contains("href=\"/docs/types/"))
                        {
                            fieldInfo.IsPrimitive = true;

                        }
                        else
                        {
                            var typeLink = td.SelectSingleNode("a");
                            if (!typeLink.Attributes["href"].Value.StartsWith("/docs/types"))
                            {
                                throw new Exception("unexpected type");
                            }
                            fieldType = typeLink.InnerText;
                        }


                        if (fieldType.Contains("an array of"))
                        {
                            fieldInfo.IsArray = true;
                            if (fieldInfo.IsPrimitive)
                            {
                                fieldType = fieldType.Replace("an array of", "").Trim();
                                if (fieldType == "strings")
                                {
                                    fieldType = "string";

                                }
                                else
                                {
                                    throw new Exception("unexpected field array type: " + fieldType);
                                }
                            }

                        }
                        if (fieldType.Contains("one of"))
                        {
                            fieldInfo.IsEnum = true;
                            fieldType = fieldType.Replace(", or ", ", ");
                            fieldType = fieldType.Replace("one of", "");



                        }
                        //







                        if (fieldInfo.IsEnum)
                        {
                            fieldInfo.EnumValues = fieldType;
                            fieldType = Type + " " + fieldName;

                        }



                        //// clean up repeated words ?


                        fieldType = fieldType.Replace("-", " ");
                        fieldType = fieldType.Replace("_", " ");
                        fieldType = fieldType.Trim();

                        Regex doubleWordPattern = new Regex("\\b(?<word>\\w+)\\s+(\\k<word>)\\b");
                        var doubleWordPatternMatch = doubleWordPattern.Match(fieldType);
                        if (doubleWordPatternMatch.Success)
                        {
                            string word = doubleWordPatternMatch.Groups["word"].Value;
                            fieldType = doubleWordPattern.Replace(fieldType, word);
                        }
                        fieldType = fieldType.Replace(" ", "_").Replace("-", "_");
                        fieldInfo.Type = fieldType;
                        if (fieldInfo.IsEnum)
                        {
                            var type = new TypeInfo(Docs);
                            type.Type = fieldType;
                            type.Name = fieldType;
                            type.IsEnum = true;
                            type.Inferred = true;
                            foreach (string item in fieldInfo.EnumValues.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                var f = new FieldInfo();
                                f.Type = "string";
                                f.Name = item.Trim();
                                type.Fields.Add(f);

                            }
                            this.Docs.Types.Add(type);
                        }

                        // #EDGE CASE
                        if (fieldType == "the_type_found_in_type")
                        {
                            GenericType = fieldType;
                            fieldInfo.IsPrimitive = false;
                        }

                    }
                }
            }



        }
    }
}
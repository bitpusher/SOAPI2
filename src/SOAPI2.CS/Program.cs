using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SOAPI2.CS
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //GetDataTypes();
                //GetDataTypes();
                //GenerateTypes();
                GenerateRoute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }
        private static void GenerateRoute()
        {
            var methodTxt = File.ReadAllText("..\\..\\MethodListParsed.txt");

            JObject methodObj = (JObject)JsonConvert.DeserializeObject(methodTxt);
            JObject localMethods = (JObject)methodObj["local"];
            JObject globalMethods = (JObject)methodObj["global"];

            var sb = new StringBuilder();


            sb.AppendLine("using System;");
            sb.AppendLine("using Newtonsoft.Json;");
            sb.AppendLine("using SOAPI2.Converters;");
            sb.AppendLine("using SOAPI2.Domain;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Salient.ReliableHttpClient;");

            sb.AppendLine("");
            sb.AppendLine("namespace SOAPI2");
            sb.AppendLine("{");
            sb.AppendLine("");
            sb.AppendLine("\tpublic partial class Client");
            sb.AppendLine("\t{");

            sb.AppendLine("\t\tpublic class __global");
            //
            //
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t");
            sb.AppendLine("\t\t");
            sb.AppendLine("\t\tprivate Client _client;");
            sb.AppendLine("\t\t");
            sb.AppendLine("\t\tpublic __global(Client client){ this._client = client;}");
            //
            foreach (KeyValuePair<string, JToken> group in globalMethods)
            {
                JObject methods = (JObject)group.Value;
                foreach (KeyValuePair<string, JToken> keyValuePair in methods)
                {
                    JObject method = (JObject)keyValuePair.Value;
                    JToken returnValue = method["returns"];
                    string returnValueType = returnValue.ToString();
                    Debug.WriteLine(returnValueType);
                    switch (returnValueType)
                    {
                        case "ERROR":
                            returnValueType = "error";
                            break;
                        default:

                            break;
                    }
                    returnValueType = FixTypeName(returnValueType);
                    returnValueType = "ListOf<" + returnValueType + ">";
                    string methodName = FixMethodName(keyValuePair.Key);


                    List<string> parameterList = new List<string>();
                    List<string> optionalParameterList = new List<string>();

                    JObject paramsArray = (JObject)method["parameters"];
                    string paramTypeName = "object";
                    parameterList.Add("ReliableAsyncCallback callback");
                    parameterList.Add("object state");
                    string uri = method["uri"].ToString();
                    foreach (KeyValuePair<string, JToken> valuePair in paramsArray)
                    {
                        string paramName = valuePair.Key;
                        switch (paramName)
                        {
                            case "base":
                            case "unsafe":
                                paramName = "@" + paramName;
                                break;
                            case "scope":
                                continue;
                            default:

                                string paramType = valuePair.Value.ToString();

                                switch (paramType)
                                {

                                    case "boolean":
                                    case "[\r\n  \"false\",\r\n  \"true\"\r\n]":
                                        paramTypeName = "bool";
                                        break;
                                    case "string":
                                    case "access_token":
                                        paramTypeName = "string";
                                        break;
                                    case "date":
                                        paramTypeName = "DateTime";
                                        break;
                                    case "string list":
                                        paramTypeName = "string";
                                        break;
                                    case "number list":
                                        paramTypeName = "string";
                                        break;
                                    case "number":

                                        paramTypeName = "int";
                                        break;
                                    default:
                                        Debugger.Break();
                                        break;
                                }
                                break;
                        }

                        if (uri.Contains("{" + paramName + "}"))
                        {
                            parameterList.Add(paramTypeName + " " + paramName);
                        }
                        else
                        {
                            string optionalParamType = "null";
                            string optionalParamTypeName = paramTypeName;
                            switch (paramTypeName)
                            {
                                case "string":
                                    break;
                                case "int":
                                case "bool":
                                case "DateTime":
                                    optionalParamTypeName = optionalParamTypeName + "?";
                                    break;
                                default:
                                    Debugger.Break();
                                    break;
                            }
                            optionalParameterList.Add(optionalParamTypeName + " " + paramName + "=" + optionalParamType);
                        }

                    }



                    parameterList.AddRange(optionalParameterList);
                    string parms = string.Join(", ", parameterList.ToArray());
                    sb.AppendLine("\t\tpublic void Begin" + methodName + "(" + parms + "){}");
                    sb.AppendLine("\t\t");
                    sb.AppendLine("\t\tpublic void End" + methodName + "(ReliableAsyncResult asyncResult){}");
                    sb.AppendLine("\t\t");

                    parameterList.Remove("ReliableAsyncCallback callback");
                    parameterList.Remove("object state");
                    parms = string.Join(", ", parameterList.ToArray());

                    sb.AppendLine("\t\t");
                    sb.AppendLine("\t\tpublic " + returnValueType + " " + methodName + "(" + parms + "){ return null;}");
                    sb.AppendLine("\t\t");

                }
            }
            sb.AppendLine("\t\t}");




            sb.AppendLine("\t}");
            sb.AppendLine("");


            sb.AppendLine("}");
            File.WriteAllText("..\\..\\..\\SOAPI2\\Routes.cs", sb.ToString());
        }
        private static void GenerateTypes()
        {
            var sb = new StringBuilder();


            sb.AppendLine("using System;");
            sb.AppendLine("using Newtonsoft.Json;");
            sb.AppendLine("using SOAPI2.Converters;");

            sb.AppendLine("");
            sb.AppendLine("namespace SOAPI2.Domain");
            sb.AppendLine("{");
            var typesJson = File.ReadAllText("..\\..\\TypesListParsed.txt");
            JObject types = (JObject)JsonConvert.DeserializeObject(typesJson);

            foreach (var kvp in types)
            {
                string typeName = kvp.Key;
                var FixedTypeName = FixTypeName(typeName);
                sb.AppendLine("");
                sb.AppendLine("\tpublic class " + FixedTypeName + "{");
                sb.AppendLine("");
                JObject type = (JObject)kvp.Value;
                JObject properties = (JObject)type["properties"];
                foreach (var keyValuePair in properties)
                {
                    bool isObject = false;
                    JObject property = (JObject)keyValuePair.Value;
                    bool isRequired = property["required"].Value<bool>();
                    string propertyType = "VOID";
                    bool isArray = false;
                    JToken t = property["type"];
                    if (t.Type == JTokenType.String)
                    {
                        if (t.ToString() == "array")
                        {
                            isArray = true;
                            JToken arrayType = ((JArray)property["values"])[0];
                            if (arrayType.Type == JTokenType.String)
                            {
                                propertyType = arrayType.Value<string>();
                                propertyType = ConvertPropertyType(propertyType);
                            }
                            else
                            {
                                propertyType = ((JObject)arrayType)["$ref"].Value<string>().Substring(1);
                                propertyType = FixTypeName(propertyType);
                                isObject = true;
                            }
                        }
                        else
                        {
                            propertyType = t.ToString();
                            propertyType = ConvertPropertyType(propertyType);
                        }
                    }
                    else
                    {
                        propertyType = ((JObject)t)["$ref"].Value<string>().Substring(1);
                        propertyType = FixTypeName(propertyType);
                        isObject = true;
                    }

                    string propertyName = FixPropertyName(keyValuePair.Key);
                    if (isArray)
                    {
                        propertyType = propertyType + "[]";
                    }
                    else
                    {
                        if (!isRequired && !isObject)
                        {
                            switch (propertyType)
                            {
                                case "string":
                                    break;
                                case "DateTime":
                                case "int":
                                case "bool":

                                    propertyType = propertyType + "?";
                                    break;
                                default:
                                    Debugger.Break();
                                    break;
                            }
                        }
                    }
                    if (!isObject && !isArray)
                    {
                        switch (propertyType)
                        {
                            case "string":
                            case "int":
                            case "int?":
                            case "decimal":
                            case "bool":
                                break;
                            case "DateTime":
                            case "DateTime?":
                                sb.AppendLine("\t\t[JsonConverter(typeof(UnixDateTimeConverter))]");

                                break;
                            default:
                                Debugger.Break();
                                break;

                        }

                    }
                    sb.AppendLine("\t\t[JsonProperty(\"" + keyValuePair.Key + "\")]");
                    sb.AppendLine("\t\tpublic " + propertyType + " " + propertyName + " {get;set;}");
                    sb.AppendLine("");
                }

                sb.AppendLine("\t}");
            }

            sb.AppendLine("}");
            File.WriteAllText("..\\..\\..\\SOAPI2\\Domain\\Types.cs", sb.ToString());
        }

        private static string ConvertPropertyType(string propertyType)
        {
            switch (propertyType)
            {
                case "string":
                case "decimal":

                    break;
                case "integer":
                    propertyType = "int";
                    break;
                case "boolean":
                    propertyType = "bool";
                    break;
                case "date":
                    propertyType = "DateTime";
                    break;
                default:
                    Debugger.Break();
                    break;
            }
            return propertyType;
        }

        private static string FixPropertyName(string name)
        {
            TextInfo tinfo = new CultureInfo("en-US", false).TextInfo;
            string FixedName = name.Replace("_", " ");
            FixedName = tinfo.ToTitleCase(FixedName).Replace(" ", "");
            return FixedName;
        }
        private static string FixTypeName(string name)
        {
            TextInfo tinfo = new CultureInfo("en-US", false).TextInfo;
            string FixedName = name.Replace("-", " ");
            FixedName = tinfo.ToTitleCase(FixedName).Replace(" ", "") + "Object";
            return FixedName;
        }
        private static string FixMethodName(string name)
        {
            TextInfo tinfo = new CultureInfo("en-US", false).TextInfo;
            string FixedName = name.Replace("-", " ");
            FixedName = tinfo.ToTitleCase(FixedName).Replace(" ", "");
            return FixedName;
        }

        private static void GetDataTypes()
        {
            CreateDirectories();
            var methodTxt = File.ReadAllText("..\\..\\MethodList.txt");

            JObject methodObj = (JObject)JsonConvert.DeserializeObject(methodTxt);
            JObject localMethods = (JObject)methodObj["local"];
            JObject globalMethods = (JObject)methodObj["global"];


            ParseDocs(localMethods);
            ParseDocs(globalMethods);
            methodTxt = methodObj.ToString();
            File.WriteAllText("..\\..\\MethodListParsed.txt", methodTxt);

            //FetchReturnTypes(methodTxt);

            string typesTxt = File.ReadAllText("..\\..\\TypesList.txt");
            JObject typesObj = (JObject)JsonConvert.DeserializeObject(typesTxt);

            while (ParseTypes(typesObj))
            {
                //noop
            }

            typesTxt = typesObj.ToString();
            File.WriteAllText("..\\..\\TypesListParsed.txt", typesTxt);
        }

        private static bool ParseTypes(JObject typesObj)
        {
            bool reparse = false;

            var types = typesObj.Properties().ToArray();
            foreach (JProperty kvp in types)
            {
                string typeName = kvp.Name;
                JObject typeObj = (JObject)kvp.Value;

                if (typeObj["parsed"].Value<bool>())
                {
                    continue;
                }
                string doc = File.ReadAllText(string.Format("..\\..\\html\\types\\{0}.txt", typeName));


                doc = doc.Substring(doc.IndexOf("<h2>Discussion</h2>"));
                doc = doc.Substring(doc.IndexOf("<div class=\"indented\">"));
                string description = doc.Substring(0, doc.IndexOf("</div>"));
                doc = doc.Substring(description.Length);
                description = Regex.Replace(description, "\\<.*?>", "");
                description = description.Replace("&ndash;", "-");
                description = description.Trim();
                typeObj["id"] = typeName;
                typeObj["description"] = description;
                typeObj["properties"] = new JObject();
                doc = doc.Substring(0, doc.IndexOf("<h2>Examples</h2>"));
                //
                int pos = doc.IndexOf("<div class=\"method\">");
                while (pos > -1)
                {
                    int pos2 = doc.IndexOf("<div class=\"method\">", pos + 1);
                    string field = "";
                    if (pos2 == -1)
                    {
                        field = doc.Substring(pos);
                    }
                    else
                    {
                        field = doc.Substring(pos, pos2 - pos);
                    }

                    // 
                    string fieldName =
                        Regex.Match(field, "\\<div class=\"method-name\">(.*?)\\</div>", RegexOptions.Singleline).Groups[1].
                            Value;
                    fieldName =
                        fieldName.Replace(
                            "<span class=\"min-version\" title=\"introduced in version 2.1\">2.1</span>", "");
                    bool isIncludedInDefaultFilter = false;
                    if (Regex.IsMatch(fieldName,
                                      "\\<span class=\"included\" title=\"this field is included in the default filter\">\\</span>"))
                    {

                        isIncludedInDefaultFilter = true;
                    }



                    fieldName = Regex.Replace(fieldName, "\\<.*?>", "");

                    fieldName = fieldName.Trim();
                    var fieldObj = new JObject();
                    typeObj["properties"][fieldName] = fieldObj;

                    fieldObj["isIncludedInDefaultFilter"] = isIncludedInDefaultFilter;
                    List<string> values = null;
                    // 
                    string fieldType =
                        Regex.Match(field, "\\<div class=\"method-description\">(.*?)\\</div>", RegexOptions.Singleline).Groups[
                            1].Value;

                    string fieldDescription = Regex.Replace(fieldType, "\\<.*?>", "");
                    fieldDescription = fieldDescription.Trim();
                    fieldObj["decscription"] = fieldDescription;
                    //

                    if (fieldType.IndexOf("<br />unchanged in <a href=\"/docs/filters\">unsafe filters</a>") > -1)
                    {

                        fieldObj["unchangedInUnsafeFilters"] = true;
                        fieldType =
                            fieldType.Replace(
                                "<br />unchanged in <a href=\"/docs/filters\">unsafe filters</a>", "");
                    }

                    if (fieldType.IndexOf("<br /><a href=\"/docs/absent-fields\">may be absent</a>") > -1)
                    {
                        fieldObj["required"] = false;

                        fieldType =
                            fieldType.Replace(
                                "<br /><a href=\"/docs/absent-fields\">may be absent</a>", "");
                    }
                    else
                    {
                        fieldObj["required"] = true;
                    }

                    fieldType = fieldType.Trim();

                    pos = fieldType.IndexOf(", refers to a");
                    if (pos > -1)
                    {
                        fieldType = fieldType.Substring(0, pos).Trim();
                    }
                    bool isObject = false;
                    bool isArray = false;
                    if (fieldType.StartsWith("an array of"))
                    {
                        isArray = true;

                        fieldType = fieldType.Substring("an array of".Length).Trim();
                        if (fieldType == "strings")
                        {
                            fieldType = "string";
                        }
                    }
                    if (fieldType == "string" || fieldType == "integer" || fieldType == "boolean" || fieldType == "decimal")
                    {
                    }
                    //

                    else if (fieldType == "<a href=\"/docs/dates\">date</a>")
                    {
                        fieldType = "date";
                    }
                    else if (fieldType.StartsWith("one of"))
                    {
                        //one of <code>question</code>, or <code>answer</code>
                        values = new List<string>();
                        var matches = Regex.Matches(fieldType, "\\<code\\>(.*?)\\</code>");
                        foreach (Match match in matches)
                        {
                            values.Add(match.Groups[1].Value);
                        }
                        fieldType = "string";


                    }
                    //
                    else if (
                        fieldType.EndsWith(
                            " strings, but <a href=\"/docs/unsealed-enumerations\">new options may be added</a>."))
                    {
                        isArray = true;

                        fieldType = "string";
                    }
                    //
                    else if (Regex.IsMatch(fieldType, "\\<a href=\"/docs/types/.*\">.*\\</a>"))
                    {
                        fieldType = Regex.Match(fieldType, "\\<a href=\"/docs/types/(.*)\">.*\\</a>").Groups[1].Value;
                        isObject = true;
                        if (typesObj[fieldType] == null)
                        {
                            var obj = FetchType(fieldType);
                            typesObj[fieldType] = obj;
                            reparse = true;
                        }
                        // check typeobj for type, fetch if necessary
                    }
                    else if (fieldType.StartsWith("the id of the object"))
                    {
                        fieldType = "integer";
                    }
                    else
                    {
                        throw new Exception("could not parse field name" + fieldName + " type " + fieldType + "on object " +
                                            typeName);
                    }

                    if (isArray)
                    {
                        fieldObj["type"] = "array";
                        if (isObject)
                        {
                            fieldObj["values"] = new JArray(new JObject(new JProperty("$ref", "/" + fieldType)));
                        }
                        else
                        {
                            fieldObj["values"] = new JArray(fieldType);
                        }

                    }
                    else
                    {
                        if (isObject)
                        {
                            fieldObj["type"] = new JObject(new JProperty("$ref", "/" + fieldType));
                        }
                        else
                        {
                            fieldObj["type"] = fieldType;
                        }

                    }


                    if (values != null)
                    {
                        fieldObj["enum"] = new JArray(values.ToArray());
                    }

                    pos = pos2;
                }

                typeObj["parsed"] = true;
            }

            return reparse;
        }


        private static void FetchReturnTypes(string methodTxt)
        {
            JObject typesObj = new JObject();

            var returnTypes = Regex.Matches(methodTxt, "\"returnsUrl\": \"/(.*)\",");


            foreach (Match returnType in returnTypes)
            {
                string typeUrl = returnType.Groups[1].Value;
                string typeName = typeUrl.Substring(typeUrl.LastIndexOf("/") + 1);
                if (typesObj[typeName] == null)
                {
                    try
                    {
                        var obj = FetchType(typeName);
                        typesObj[typeName] = obj;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }


            }
            var typesTxt = typesObj.ToString();
            File.WriteAllText("..\\..\\TypesList.txt", typesTxt);

        }

        private static JObject FetchType(string typeName)
        {
            var client = new WebClient();
            string url = string.Format("https://api.stackexchange.com/docs/types/{0}", typeName);

            string typeDoc = client.DownloadString(url);
            File.WriteAllText(string.Format("..\\..\\html\\types\\{0}.txt", typeName), typeDoc);
            JObject obj = new JObject();

            obj["parsed"] = false;
            Thread.Sleep(250);
            return obj;
        }

        private static void CreateDirectories()
        {
            if (!Directory.Exists("..\\..\\html\\types"))
            {
                Directory.CreateDirectory("..\\..\\html\\types");
            }
            if (!Directory.Exists("..\\..\\html\\methods"))
            {
                Directory.CreateDirectory("..\\..\\html\\methods");
            }
        }

        private static void ParseDocs(JObject methods)
        {
            foreach (KeyValuePair<string, JToken> kvp in methods)
            {
                string groupName = kvp.Key;
                JObject groupMethods = (JObject)kvp.Value;
                foreach (KeyValuePair<string, JToken> kvp2 in groupMethods)
                {
                    string methodName = kvp2.Key;
                    JObject method = (JObject)kvp2.Value;
                    string filePath = string.Format("..\\..\\html\\methods\\{0}.txt", methodName);
                    string doc = File.ReadAllText(filePath);
                    int pos = doc.IndexOf("<div class=\"sidebar\">", System.StringComparison.Ordinal);
                    doc = doc.Substring(0, pos);
                    pos = Regex.Match(doc, "<script type=\"text/javascript\">\r\n").Index;
                    doc = doc.Substring(pos);
                    pos = doc.IndexOf("<body>");
                    string script = doc.Substring(0, pos);
                    string httpMethod = "GET";
                    if (script.IndexOf("var isPostMethod = true") > -1)
                    {
                        httpMethod = "POST";
                    }
                    var parameters = Regex.Match(script, "var parameters = (.*);").Groups[1].Value;
                    method["parameters"] = (JObject)JsonConvert.DeserializeObject(parameters);
                    var uri = Regex.Match(script, "var method = \"(.*)\";").Groups[1].Value;
                    method["uri"] = uri;
                    doc = doc.Substring(pos);
                    //
                    pos = doc.IndexOf("<div class=\"indented\">");
                    int pos2 = doc.IndexOf("</div>", pos) + 6;
                    string description = doc.Substring(pos, pos2 - pos);
                    string returnType = "";
                    string returnTypeUrl = "";
                    bool isArray = false;
                    pos = description.LastIndexOf("This method return");
                    if (pos > -1)
                    {

                        returnType = description.Substring(pos, description.IndexOf("</p>", pos) - pos);
                        if (returnType.IndexOf("This method returns a list") > -1)
                        {
                            //
                            returnTypeUrl = Regex.Match(returnType, "<a href=\"(.*?)\">").Groups[1].Value;
                            returnType = returnTypeUrl.Substring(returnTypeUrl.LastIndexOf("/") + 1);
                            isArray = true;
                        }

                        else if (returnType.IndexOf("This method return the created ") > -1
                            || returnType.IndexOf("This method returns an ") > -1 ||
                            returnType.IndexOf("This method returns a ") > -1)
                        {
                            returnTypeUrl = Regex.Match(returnType, "<a href=\"(.*?)\">").Groups[1].Value;
                            returnType = returnTypeUrl.Substring(returnTypeUrl.LastIndexOf("/") + 1);
                            isArray = false;
                        }


                        else
                        {
                            throw new Exception("could not determine return type");
                        }
                    }
                    else
                    {
                        if (description.IndexOf("In practice, this method will never return an object.") > -1)
                        {
                            returnType = "VOID";
                        }

                        else if (description.IndexOf("This method results in an error") > -1)
                        {
                            returnType = "ERROR";
                        }
                        else
                        {
                            throw new Exception("Could not find return type");
                        }

                    }

                    method["httpMethod"] = httpMethod;
                    method["returns"] = returnType;
                    method["returnsArray"] = isArray;
                    method["returnsUrl"] = returnTypeUrl;
                    description = Regex.Replace(description, "\\<.*?>", "");
                    description = description.Replace("&ndash;", "-");
                    description = description.Trim();
                    method["description"] = description;
                    doc = doc.Substring(pos2);
                }
            }
        }


        private static void FetchDocs()
        {
            var methodTxt = File.ReadAllText("..\\..\\MethodList.txt");

            JObject methodObj = (JObject)JsonConvert.DeserializeObject(methodTxt);
            JObject localMethods = (JObject)methodObj["local"];
            JObject globalMethods = (JObject)methodObj["global"];

            GetDocs(globalMethods);

            GetDocs(localMethods);
        }
        private static void GetDocs(JObject methods)
        {
            WebClient client = new WebClient();

            foreach (KeyValuePair<string, JToken> kvp in methods)
            {
                string groupName = kvp.Key;
                JObject groupMethods = (JObject)kvp.Value;
                foreach (KeyValuePair<string, JToken> kvp2 in groupMethods)
                {
                    string methodName = kvp2.Key;
                    string url = string.Format("https://api.stackexchange.com/docs/{0}", methodName);
                    Console.WriteLine(url);
                    string doc = client.DownloadString(url);
                    File.WriteAllText(string.Format("..\\..\\html\\methods\\{0}.txt", methodName), doc);
                    Thread.Sleep(250);
                }
            }
        }
    }
}

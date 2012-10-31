using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CsQuery;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Generator2
{
    class Program
    {
        private static string _docUrl = "https://api.stackexchange.com";
        private static string _docPath = "..\\..\\html";
        static void Main(string[] args)
        {
            PrepareJsonIndex();


            List<MethodInfo> methods = new List<MethodInfo>();
            Dictionary<string, List<GroupInfo>> methodDocs = GetMethodDocs();

            foreach (KeyValuePair<string, List<GroupInfo>> pair in methodDocs)
            {
                foreach (GroupInfo groupInfo in pair.Value)
                {
                    foreach (var methodInfo in groupInfo.Methods)
                    {
                        methods.Add(methodInfo);
                    }
                }
            }

            foreach (var method in methods)
            {
                
                string doc = method.DocUrl.FetchUrl(method.DocPath);
            }
            


            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        private static Dictionary<string, List<GroupInfo>> GetMethodDocs()
        {
            string documentationJsonIndexPath = GetDocumentationJsonIndexPath();
            Dictionary<string, List<GroupInfo>> methodDocs = JsonConvert.DeserializeObject<Dictionary<string, List<GroupInfo>>>(File.ReadAllText(documentationJsonIndexPath));
            return methodDocs;
        }
        private static void PrepareJsonIndex()
        {
            string documentationJsonIndexPath = GetDocumentationJsonIndexPath();
            string documentationHtmlIndexPath = GetDocumentationHtmlIndexPath();

            string documentationIndex = (_docUrl + "/docs").FetchUrl(documentationHtmlIndexPath);
            var groupList = new Dictionary<string, List<GroupInfo>>();
            var localGroups = new List<GroupInfo>();
            var globalGroups = new List<GroupInfo>();
            groupList.Add("Local", localGroups);
            groupList.Add("Global", globalGroups);

            CQ DocumentationIndexDom = CQ.Create(documentationIndex);

            var headings = DocumentationIndexDom.Select("h2");

            var localGroupDom = CQ.CreateFragment(headings[2].NextElementSibling.Render());
            var globalGroupDom = CQ.CreateFragment(headings[3].NextElementSibling.Render());


            PrepareIndex(localGroups, false, localGroupDom);
            PrepareIndex(globalGroups, true, globalGroupDom);

            string json = JsonConvert.SerializeObject(groupList, Formatting.Indented);

            File.WriteAllText(documentationJsonIndexPath, json);
        }

        private static string GetDocumentationHtmlIndexPath()
        {
            return Path.Combine(_docPath, "docs.txt");
        }

        private static string GetDocumentationJsonIndexPath()
        {
            return Path.Combine(_docPath, "docs.json");
        }

        private static string GetDocumentationMethodPath(string name, bool global)
        {
            return Path.Combine(_docPath + "\\" + (global ? "global" : "local"), name + ".txt");
        }
        private static void PrepareIndex(List<GroupInfo> groups, bool isGlobal, CQ currentGroupDom)
        {
            var sel2 = currentGroupDom.Select("h3");
            sel2.Each((i, e) =>
                          {
                              var groupName = e.InnerHTML;
                              var groupObj = new GroupInfo() { Global = isGlobal, Name = groupName };
                              groups.Add(groupObj);
                              Console.WriteLine("GROUP: {0}", groupName);
                              var methodGroup = CQ.Create(e.NextElementSibling);
                              var methods = methodGroup.Select(".method");
                              Console.WriteLine("\t{0} methods found", methods.Count());
                              foreach (IDomObject method in methods)
                              {
                                  var methodObj = new MethodInfo();
                                  groupObj.Methods.Add(methodObj);
                                  var methodDom = CQ.Create(method.Render());
                                  var methodName = CQ.Create(methodDom.Select(".method-name")[0].FirstElementChild.Render());

                                  methodObj.DocUrl = _docUrl + methodName.Attr("href");
                                  methodObj.UriTemplate = methodName.Text();
                                  methodObj.Name =
                                      methodObj.DocUrl.Substring(methodObj.DocUrl.LastIndexOf("/") + 1).PascalCase();


                                  methodObj.ShortDescription = methodDom.Select(".method-description")[0].InnerText.Trim();

                                  methodObj.DocPath = GetMethodDocPath(isGlobal, methodObj);

                                  (methodObj.DocUrl).FetchUrl(methodObj.DocPath);

                                  var meMethodName = methodDom.Select(".me-method");

                                  if (meMethodName.Any())
                                  {
                                      GroupInfo meGroup = groups.FirstOrDefault(g => g.Name == "Me");
                                      if (meGroup == null)
                                      {
                                          meGroup = new GroupInfo() { Name = "Me", Global = isGlobal };
                                          groups.Add(meGroup);
                                      }

                                      var meMethodObj = new MethodInfo();
                                      meGroup.Methods.Add(meMethodObj);
                                      var meMethodNameDom = CQ.Create(meMethodName[0].Render());

                                      meMethodObj.DocUrl = _docUrl + meMethodNameDom.Attr("href");
                                      meMethodObj.UriTemplate = meMethodNameDom.Text();
                                      meMethodObj.Name =
                                          meMethodObj.DocUrl.Substring(meMethodObj.DocUrl.LastIndexOf("/") + 1).PascalCase();
                                      meMethodObj.DocPath = GetMethodDocPath(isGlobal, meMethodObj);
                                      meMethodObj.ShortDescription = methodObj.ShortDescription;
                                      (meMethodObj.DocUrl).FetchUrl(meMethodObj.DocPath);
                                  }
                              }
                          });
        }



        private static string GetMethodDocPath(bool global, MethodInfo method)
        {
            return Path.Combine(_docPath + "\\methods\\" + (global ? "global" : "local"), method.Name + ".txt");
        }
    }
}

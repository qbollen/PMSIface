using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Utils
{
    public class MyXml
    {
        private static string _cfg = "SpecCfg.xml";
        public MyXml(string fileName)
        {
        }

        public static void NewMap(string fileName, Dictionary<string,string> keyValue)
        {
            string path = "Spec/";
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                XmlDocument xmldoc = new XmlDocument();
                XmlDeclaration xmldecl = xmldoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmldoc.AppendChild(xmldecl);

                XmlElement root = xmldoc.CreateElement("Map");
                xmldoc.AppendChild(root);
                        
                XmlElement xmlInstruct = xmldoc.CreateElement("Instruct");
                root.AppendChild(xmlInstruct);
                XmlElement xmlSeparator = xmldoc.CreateElement("Separator");
                xmlSeparator.InnerText = keyValue["Separator"];
                root.AppendChild(xmlSeparator);
                XmlElement xmlDateTimeFormat = xmldoc.CreateElement("DateTimeFormat");
                root.AppendChild(xmlDateTimeFormat);
                XmlElement xmlAnswer = xmldoc.CreateElement("Answer");
                root.AppendChild(xmlAnswer);

                foreach (string key in keyValue.Keys)
                {
                    if (key.Length == 2)
                    {
                        XmlElement instruct = xmldoc.CreateElement(key);
                        instruct.InnerText = keyValue[key];
                        xmlInstruct.AppendChild(instruct);
                    }
                    else if (key == "Date" || key == "Time")
                    {
                        XmlElement format = xmldoc.CreateElement(key);
                        format.InnerText = keyValue[key];
                        xmlDateTimeFormat.AppendChild(format);
                    }
                    else if (key == "Success" || key == "Failure")
                    {
                        XmlElement answer = xmldoc.CreateElement(key);
                        answer.InnerText = keyValue[key];
                        xmlAnswer.AppendChild(answer);
                    }
                }
                xmldoc.Save(path + fileName);
            }
            catch(Exception e)
            {
                throw new Exception("Create xml error. " + e.Message );
            }
        }

        public static Dictionary<string,string> XmlToDictionary(string fileName)
        {
            fileName = "Spec/" + fileName + ".xml";
            Dictionary<string, string> xmldict = new Dictionary<string, string>();
            try
            {
                if (!File.Exists(fileName))
                    return null;
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(fileName);
                XmlNode instruct = xmldoc.SelectSingleNode("Map/Instruct");
                foreach (XmlNode node in instruct.ChildNodes)
                {
                    xmldict.Add(node.Name,node.InnerText);
                }
                XmlNode separator = xmldoc.SelectSingleNode("Map/Separator");
                xmldict.Add(separator.Name, separator.InnerText);

                XmlNode format = xmldoc.SelectSingleNode("Map/DateTimeFormat");
                foreach(XmlNode node in format.ChildNodes)
                {
                    xmldict.Add(node.Name,node.InnerText);
                }

                XmlNode answer = xmldoc.SelectSingleNode("Map/Answer");
                foreach (XmlNode node in answer.ChildNodes)
                {
                    xmldict.Add(node.Name, node.InnerText);
                }
            }
            catch
            {
                return null;
            }

            return xmldict;
        }

        public static bool SetSpec(string fileName)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(_cfg);

                XmlNode spec = xmldoc.SelectSingleNode("Spec");
                spec.InnerText = fileName;
                xmldoc.Save(_cfg);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static string GetSpec()
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(_cfg);
                XmlNode spec = xmldoc.SelectSingleNode("Spec");
                return spec.InnerText;
            }
            catch
            {
                return null;
            }
        }

        public static Dictionary<string,string> GetInstructMap(out string specName)
        {
            string spec = GetSpec();
            if (string.IsNullOrEmpty(spec))
            {
                specName = null;
                return null;
            }

            specName = spec;

            Dictionary<string, string> content = XmlToDictionary(spec);
            if (content == null)
            {
                return null;
            }

            return content;
        }

    }
}

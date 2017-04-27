using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace KnowledgeBaseAllInOne
{
    public partial class LoadSaveXml : Form
    {
        private static string xmlFileName = "file.xml";
        private static XmlDocument xmlDoc;
        private static XmlNode rootNode;

        public LoadSaveXml()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            xmlFileName = Path.Combine(Application.StartupPath, xmlFileName);
        }

        private void LoadXml()
        {
            if (!File.Exists(xmlFileName))
            {
                CreateDefaultXml();
            }

            xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(xmlFileName);
            }
            catch (Exception ex)
            {

            }
            rootNode = xmlDoc.DocumentElement;
        }

        public static void CreateDefaultXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(
                "<root>" +
                "<Settings>" +
                    "<Languages>" +
                        "<lang name=\"Български\">bg</lang>" +
                        "<lang name=\"Английски\">en</lang>" +
                    "</Languages>" +
                    "<CurrentLanguage>bg</CurrentLanguage>" +
                "</Settings>" +
                "</root>");

            xmlDoc.Save(xmlFileName);
        }

        public static void SaveToXML()
        {
            xmlDoc.Save(xmlFileName);
        }

        public static string GetLanguage()
        {
            return rootNode["Settings"]["CurrentLanguage"].InnerText;        
        }

        public static void SetLanguage(string lang)
        {
            rootNode["Settings"]["CurrentLanguage"].InnerText = lang;
            SaveToXML();
        }
    }
}

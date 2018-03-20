using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;
using Mercure.Controller;

namespace Mercure.Controller
{
    class ControllerFurniture
    {
        private List<Article> ListArticles;
        private static string PathXML;

        public static string GetterSetterPathXML
        {
            get
            {
                return PathXML;
            }

            set
            {
                PathXML = value;
            }
        }

        public ControllerFurniture()
        {
            ListArticles = new List<Article>();
        }

        public bool LoadXML()
        {
            XmlDocument XMLDoc = new XmlDocument();

            try
            {
                XMLDoc.Load(PathXML);

            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Error XMLfile not found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Read XML
            XmlNode NodeRoot = XMLDoc.SelectSingleNode("materiels");

            XmlNodeList NodeListRoot = NodeRoot.ChildNodes;

            foreach (XmlNode Node in NodeListRoot)
            {
                Article Article = new Article();

                XmlElement XMLElement = (XmlElement)Node;

                XmlNodeList NodeList = XMLElement.ChildNodes;

                Article.GetSetDescription = NodeList.Item(0).InnerText;
                Article.GetSetReference = NodeList.Item(1).InnerText;
                Article.GetSetBrand = NodeList.Item(2).InnerText;
                Article.GetSetFamilly = NodeList.Item(3).InnerText;
                Article.GetSetSubFamilly = NodeList.Item(4).InnerText;
                Article.GetSetPriceHT = Convert.ToDouble(NodeList.Item(5).InnerText);

                ListArticles.Add(Article);
            }

            if (ListArticles.Count != 0)
                return true;

            return false;
        }

        public void NewXMLImport()
        {
            Console.WriteLine("New BD XML IMPORT");

            SQLiteConnection M_dbConnection = SingletonBD.GetInstanceBD;


            string SqlInsert = "insert into highscores (name, score) values ('Me', 9001)";
        }

        public void UpdateXMLImport()
        {
            Console.WriteLine("Update BD XML IMPORT");
        }
    }
}

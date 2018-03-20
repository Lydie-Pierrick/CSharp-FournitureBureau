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
        private string PathXML;
        private static SQLiteConnection DbConnection;
        private List<String> ListNameTables;

        public string GetterSetterPathXML
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
            DbConnection = SingletonBD.GetInstanceBD;
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

        public void GetAllNameTables()
        {
            String DeleteSQL = "SELECT name FROM my_db.sqlite_master WHERE type='table';";
            SQLiteCommand Delete = new SQLiteCommand(DeleteSQL, DbConnection);

            Delete.Connection.Open();

            SQLiteDataReader DeleteReader = Delete.ExecuteReader();

            try
            {
                while (DeleteReader.Read())
                {
                    ListNameTables.Add(DeleteReader.GetString(0));
                }
            }
            finally
            {
                DeleteReader.Close();
                Delete.Connection.Close();
            }
        }

        public void NewXMLImport()
        {
            Console.WriteLine("New BD XML IMPORT");

            String DeleteSQL = "";
            SQLiteCommand Delete = new SQLiteCommand(DeleteSQL, DbConnection);

            Delete.Connection.Open();
            Delete.ExecuteNonQuery();

            String InsertSQL = "";
            SQLiteCommand Insert = new SQLiteCommand(InsertSQL, DbConnection);

            Insert.Connection.Open();
            Insert.ExecuteNonQuery();
        }

        public void UpdateXMLImport()
        {
            Console.WriteLine("Update BD XML IMPORT");

            String UpdateSQL = "";
            SQLiteCommand Update = new SQLiteCommand(UpdateSQL, DbConnection);

            Update.Connection.Open();
            Update.ExecuteNonQuery();
        }
    }
}

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
using System.Data.SqlClient;

namespace Mercure.Controller
{
    class ControllerFurniture
    {
        private List<Article> ListArticles;
        private string PathXML;
        private static SQLiteConnection DbConnection;
        private List<String> ListNameTables;

        public ControllerFurniture()
        {
            DbConnection = SingletonBD.GetInstance.GetDB();
            ListArticles = new List<Article>();
            ListNameTables = GetAllNameTables();           
        }

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

        private List<String> GetAllNameTables()
        {
            List<string> List = new List<string>();
            string DeleteSQL = "SELECT name FROM sqlite_master WHERE type='table';";            

            using (DbConnection)
            {
                SQLiteCommand Delete = new SQLiteCommand(DeleteSQL, DbConnection);

                try
                {
                    if (DbConnection == null || DbConnection.State != System.Data.ConnectionState.Open)
                        throw new Exception("Error database !");
                } catch (Exception e)
                {
                    MessageBox.Show("Error database ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SQLiteDataReader DeleteReader = Delete.ExecuteReader();

                if (DeleteReader.HasRows)
                {
                    try
                    {
                        while (DeleteReader.Read())
                        {
                            List.Add(DeleteReader.GetString(0));
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error during delete row database ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return List;
        }

        public void NewXMLImport()
        {
            using (DbConnection)
            {
                try
                {
                    if (!DeleteAllEntriesTables())
                    {
                        throw new Exception("Reset database failed");
                    }

                    String InsertSQL = "";
                    SQLiteCommand Insert = new SQLiteCommand(InsertSQL, DbConnection);

                    Insert.Connection.Open();
                    Insert.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error during new import XML ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool DeleteAllEntriesTables()
        {
            int countResetTable = 0;
            String DeleteSQL;
            SQLiteCommand Delete;

            foreach (String tableName in ListNameTables)
            {
                DeleteSQL = "DELETE FROM " + tableName + ";";
                Delete = new SQLiteCommand(DeleteSQL, DbConnection);
                Delete.ExecuteNonQuery();
                countResetTable++;
            }

            if(countResetTable == ListNameTables.Count)
            {
                return true;
            }

            return false;
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

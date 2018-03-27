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
        private string PathXML;
        private List<String> ListNameTables;

        public ControllerFurniture()
        {         
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

        private void LoadXML()
        {
            XmlDocument XMLDoc = new XmlDocument();

            try
            {
                XMLDoc.Load(PathXML);
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("Error XMLfile not found !");
            }            

            // Read XML
            XmlNode NodeRoot = XMLDoc.SelectSingleNode("materiels");

            XmlNodeList NodeListRoot = NodeRoot.ChildNodes;

            foreach (XmlNode Node in NodeListRoot)
            {
                Article Article = new Article();

                Article.GetSetDescription = Node.SelectSingleNode("description").InnerText;
                Article.GetSetRefArticle = Node.SelectSingleNode("refArticle").InnerText;
                Article.GetSetRefBrand = Node.SelectSingleNode("marque").InnerText;
                Article.GetSetRefFamily = Node.SelectSingleNode("famille").InnerText;
                Article.GetSetRefSubFamily = Node.SelectSingleNode("sousFamille").InnerText;
                Article.GetSetPriceHT = Convert.ToDouble(Node.SelectSingleNode("prixHT").InnerText);

                // SQL Query Insert Article
                InsertArticles(Article);
            }
        }

        // Insert Article into database
        private void InsertArticles(Article Article)
        {
            //SELECT refArticle FROM Articles WHERE Article.GetSetRefArticle
            CreateOrInsertBrand(Article.GetSetRefBrand);
            CreateOrInsertFamily(Article.GetSetRefFamily);
            CreateOrInsertSubFamily(Article.GetSetRefFamily, Article.GetSetRefSubFamily);
            CreateOrInsertArticle(Article);            
        }

        private bool CreateOrInsertArticle(Article Article)
        {
            List<string> List = new List<string>();
            string NameTableSQL = "SELECT name FROM sqlite_master WHERE type='table';";

            SQLiteCommand NameTableCommand = new SQLiteCommand(NameTableSQL, SingletonBD.GetInstance.GetDB());
            SQLiteDataReader NameTableReader = NameTableCommand.ExecuteReader();

            if (NameTableReader.HasRows)
            {
                try
                {
                    while (NameTableReader.Read())
                    {
                        List.Add(NameTableReader.GetString(0));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error during delete row database ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    NameTableReader.Close();
                }
            }

            if (exist)
            {
                /*SQLiteCommand InsertFamily = new SQLiteCommand();
                InsertFamily.CommandText = "INSERT OR IGNORE INTO Familles (RefFamille,Nom) VALUES (1,'');";
                InsertFamily.Parameters.Add(1);
                InsertFamily.Parameters.Add(1);
                InsertFamily.Parameters.Add(1);
                InsertFamily.Connection = SingletonBD.GetInstance.GetDB();
                InsertFamily.ExecuteNonQuery();

                try
                {
                    InsertSubFamily.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error during insert article. " + ex.Message);
                }*/
            }
            else
            {
                /*SQLiteCommand InsertFamily = new SQLiteCommand();
                InsertFamily.CommandText = "INSERT OR IGNORE INTO Familles (RefFamille,Nom) VALUES (1,'');";
                InsertFamily.Parameters.Add(1);
                InsertFamily.Parameters.Add(1);
                InsertFamily.Parameters.Add(1);
                InsertFamily.Connection = SingletonBD.GetInstance.GetDB();
                InsertFamily.ExecuteNonQuery();

                try
                {
                    InsertSubFamily.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error during insert article. " + ex.Message);
                }*/
            }

            return false;
        }

        // --- Create Or Insert ...

        private bool CreateOrInsertBrand(string Brand)
        {
            return false;
        }

        private bool CreateOrInsertFamily(string family)
        {
            return false;
        }

        private bool CreateOrInsertSubFamily(string family, string subFamily)
        {
            return false;
        }

        // ---

        private List<String> GetAllNameTables()
        {
            List<string> List = new List<string>();
            string NameTableSQL = "SELECT name FROM sqlite_master WHERE type='table';";            

            SQLiteCommand NameTableCommand = new SQLiteCommand(NameTableSQL, SingletonBD.GetInstance.GetDB());
            SQLiteDataReader NameTableReader = NameTableCommand.ExecuteReader();

            if (NameTableReader.HasRows)
            {
                try
                {
                    while (NameTableReader.Read())
                    {
                        List.Add(NameTableReader.GetString(0));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error during delete row database ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    NameTableReader.Close();
                }
            }

            return List;
        }

        private bool DeleteAllEntriesTables()
        {
            int countResetTable = 0;
            SQLiteCommand Delete;

            foreach (String tableName in ListNameTables)
            {                
                Delete = new SQLiteCommand();
                Delete.CommandText = "DELETE FROM " + tableName + ";";
                Delete.Connection = SingletonBD.GetInstance.GetDB();
                Delete.ExecuteNonQuery();

                countResetTable++;
            }

            if (countResetTable == ListNameTables.Count)
            {
                return true;
            }

            return false;
        }

        public bool NewXMLImport()
        {
            try
            {
                // Need to remove all entries in the database
                if (!DeleteAllEntriesTables())
                {
                    throw new Exception("Reset database failed");
                }

                LoadXML();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error during new import XML ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public void UpdateXMLImport()
        {
            Console.WriteLine("Update BD XML IMPORT");

            // TODO
        }
    }
}

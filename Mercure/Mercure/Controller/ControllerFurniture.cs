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
using Mercure.DAO;
using System.Data.SqlClient;

namespace Mercure.Controller
{
    class ControllerFurniture
    {
        private string PathXML;
        private static DaoFurniture DaoFurniture;
        private static int CounterInsertArticle;

        public ControllerFurniture()
        {
            this.PathXML = null;
            DaoFurniture = new DaoFurniture();
            ControllerFurniture.CounterInsertArticle = 0;
        }

        /*
         * Getter Setter of path XML
         */
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

        /*
         * Load XML
         */
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
                CounterInsertArticle += CreateOrModifyArticle(Article);
            }
        }

        /*  
         *  Create or modify a brand
         */
        private int CreateOrModifyArticle(Article Article)
        {
            return DaoFurniture.CreateOrModifyArticle(Article);
        }      

        // ---     

        private bool DeleteAllEntriesTables()
        {


            if (DaoFurniture.DeleteAllEntriesTables())
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

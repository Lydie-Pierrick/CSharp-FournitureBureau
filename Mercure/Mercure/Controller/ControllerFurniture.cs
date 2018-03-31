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
                Article.GetSetBrand = Node.SelectSingleNode("marque").InnerText;
                Article.GetSetFamily = Node.SelectSingleNode("famille").InnerText;
                Article.GetSetSubFamily = Node.SelectSingleNode("sousFamille").InnerText;
                Article.GetSetPriceHT = Convert.ToDouble(Node.SelectSingleNode("prixHT").InnerText);

                // SQL Query Insert Article
                CreateOrModifyArticle(Article);
                CounterInsertArticle++;
            }
        }

        /*  
         *  Create or modify a brand
         */
        private string CreateOrModifyArticle(Article Article)
        {
            string RefArticle = DaoFurniture.CreateOrModifyArticle(Article);

            Console.WriteLine(RefArticle);
            return RefArticle;
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

        public List<Article> GetAllArticles()
        {
            return DaoFurniture.GetAllArticles();
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
                //RefreshListView();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error during new import XML ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool UpdateXMLImport()
        {
            try
            {
                LoadXML();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error during new import XML ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public ListViewItem AddItemToListView(Article Article)
        {
            ListViewItem Line = new ListViewItem(Article.GetSetRefArticle);
            Line.SubItems.Add(Article.GetSetDescription);
            Line.SubItems.Add(Article.GetSetBrand);
            Line.SubItems.Add(Article.GetSetSubFamily);
            Line.SubItems.Add(Article.GetSetPriceHT.ToString());
            Line.SubItems.Add(Article.GetSetQuantity.ToString());
            return Line;
        }

        public void RefreshListView()
        {       
            int NumArticle;
            List<Article> ListArticles = GetAllArticles();
            for (NumArticle = 0; NumArticle < ListArticles.Count; NumArticle ++)
            {
                 ListViewItem Line =  AddItemToListView(ListArticles[NumArticle]);
                 MainWindow.MainWindowForm.ListViewArticles.Items.Add(Line);
            }
        }
    }
}

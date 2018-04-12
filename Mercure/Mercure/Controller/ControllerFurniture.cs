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
using Mercure.Model;
using System.Data.SqlClient;
using System.Threading;

namespace Mercure.Controller
{
    class ControllerFurniture
    {
        private string PathXML;
        private static DaoFurniture DaoFurniture;
        public static int CounterInsertOrUpdate;
        public static int NumberNodes;
        private static XmlNodeList NodeListRoot;
        private Thread ThreadUpdateStatus;
        private Thread ThreadUpdateProgressText;
        

        public ControllerFurniture()
        {
            this.PathXML = null;
            DaoFurniture = new DaoFurniture();
            ControllerFurniture.CounterInsertOrUpdate = 0;
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

        public void WriteEachArticleDB(int Index)
        {
            try
            {
                Article Article = new Article();
                // Get infomations of all nodes form NodeListRoot
                Article.GetSetDescription = NodeListRoot[Index].SelectSingleNode("description").InnerText;
                Article.GetSetRefArticle = NodeListRoot[Index].SelectSingleNode("refArticle").InnerText;
                Article.GetSetBrand = NodeListRoot[Index].SelectSingleNode("marque").InnerText;
                Article.GetSetFamily = NodeListRoot[Index].SelectSingleNode("famille").InnerText;
                Article.GetSetSubFamily = NodeListRoot[Index].SelectSingleNode("sousFamille").InnerText;
                Article.GetSetPriceHT = Convert.ToDouble(NodeListRoot[Index].SelectSingleNode("prixHT").InnerText);

                // Write this Article into DB
                CreateOrModifyArticle(Article);

                // Start a new thread to update the status text
                ThreadUpdateStatus = new Thread(new ParameterizedThreadStart(UpdateStatusText));
                ThreadUpdateStatus.Start(Article);

                string TextProgress = (Index + 1) + "/" + NumberNodes;
                // Start a new thread to update the status text
                ThreadUpdateProgressText = new Thread(new ParameterizedThreadStart(UpdateProgressText));
                ThreadUpdateProgressText.Start(TextProgress);
            }        
            catch(Exception e)
            {
                Dialog_SelectionXML.DialogSelectionXML.TextBoxStatusImport.AppendText(e.Message);
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
                // Read XML
                XmlNode NodeRoot = XMLDoc.SelectSingleNode("materiels");
                // Get all the nodes
                NodeListRoot = NodeRoot.ChildNodes;
                // Get the number of nodes
                NumberNodes = NodeListRoot.Count;
            }
            catch (System.IO.FileNotFoundException)
            {
                Dialog_SelectionXML.DialogSelectionXML.TextBoxStatusImport.AppendText("Error XMLfile not found !");
            }
            catch (Exception e)
            {
                Dialog_SelectionXML.DialogSelectionXML.TextBoxStatusImport.AppendText(e.Message);
            }
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

        public bool DeleteArticle(string RefArticle)
        {
            return DaoFurniture.DeleteArticle(RefArticle);
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

        public void CreateOrModifyArticle(Article Article)
        {
            try
            {
                DaoFurniture.CreateOrModifyArticle(Article);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ListViewItem AddArticleToListView(Article Article)
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

            MainWindow.MainWindowForm.ListViewArticles.Items.Clear();

            // Show all the data on the ListView
            for (NumArticle = 0; NumArticle < ListArticles.Count; NumArticle ++)
            {
                ListViewItem Line = AddArticleToListView(ListArticles[NumArticle]);
                MainWindow.MainWindowForm.ListViewArticles.Items.Add(Line);
            }

            // Autoresize widths of columns
            foreach (ColumnHeader ColumnHeader in MainWindow.MainWindowForm.ListViewArticles.Columns)
            {
                // Width changes with the texts as well as headers
                ColumnHeader.Width = -2; 
            }
        }

        public void UpdateStatusText(Object Article)
        {
            // Delegate for updating TextBoxStatusImport in another dialog
            Action<Article> Delegate = delegate(Article ArticleDelegate) 
            {
                Dialog_SelectionXML.DialogSelectionXML.TextBoxStatusImport.AppendText("[Insert or update]: Article : " + ArticleDelegate.GetSetRefArticle);
                Dialog_SelectionXML.DialogSelectionXML.TextBoxStatusImport.AppendText("\tBrand : " + ArticleDelegate.GetSetBrand);
                Dialog_SelectionXML.DialogSelectionXML.TextBoxStatusImport.AppendText("\tFamily : " + ArticleDelegate.GetSetFamily);
                Dialog_SelectionXML.DialogSelectionXML.TextBoxStatusImport.AppendText("\tSubFamily : " + ArticleDelegate.GetSetSubFamily + "\n");
                Dialog_SelectionXML.DialogSelectionXML.TextBoxStatusImport.AppendText("------------------\n");
            };

            // Invoke this component
            Dialog_SelectionXML.DialogSelectionXML.TextBoxStatusImport.Invoke(Delegate, Article);
        }

        public void UpdateProgressText(Object Text)
        {
            // Delegate for updating TextBoxStatusImport in another dialog
            Action<string> Delegate = delegate(string TextDelegate)
            {
                Dialog_SelectionXML.DialogSelectionXML.Label_Progress.Text = TextDelegate;
            };
            // Invoke this component
            Dialog_SelectionXML.DialogSelectionXML.Label_Progress.Invoke(Delegate, Text);
        }

        public List<Article> GetAllArticles()
        {
            return DaoFurniture.GetAllArticles();
        }

        public List<Brand> GetAllBrands()
        {
            return DaoFurniture.GetAllBrands();
        }

        public List<Family> GetAllFamily()
        {
            return DaoFurniture.GetAllFamily();
        }

        public List<SubFamily> GetAllSubFamily()
        {
            return DaoFurniture.GetAllSubFamily();
        }

        public List<SubFamily> GetAllSubFamilyOfFamily(string Family)
        {
            return DaoFurniture.GetAllSubFamilyOfFamily(Family);
        }

        /*
         *  Get Family id of SubFamily
         *
         *  @return id of family or -1 if it does not exist
         */
        public string GetFamilyNameOfSubFamily(string SubFamily)
        {
            int IdFamilyName = DaoFurniture.GetFamilyIdOfSubFamily(SubFamily);

            return DaoFurniture.GetFamilyName(IdFamilyName);
        }
    }
}

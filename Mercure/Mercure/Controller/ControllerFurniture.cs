﻿using System;
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
using System.Globalization;

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

        /// <summary>
        /// Default constructor
        /// </summary>
        public ControllerFurniture()
        {
            this.PathXML = null;
            DaoFurniture = new DaoFurniture();
            ControllerFurniture.CounterInsertOrUpdate = 0;
        }

        /// <summary>
        /// Getter Setter of path XML
        /// </summary>
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

        /// <summary>
        /// The action to write each article into DB
        /// </summary>
        /// <param name="Index"> The Index of node</param>
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

                Article.GetSetPriceHT = String.Format("{0:0.00}", NodeListRoot[Index].SelectSingleNode("prixHT").InnerText);

                // Write this Article into DB
                CreateOrModifyArticleXML(Article);

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
                MessageBox.Show("Error during new import XML ! " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load an XML file
        /// </summary>
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

        /// <summary>
        /// Delete all entries tables of DB
        /// </summary>
        /// <returns> The bool if success </returns>
        private bool DeleteAllEntriesTables()
        {
            if (DaoFurniture.DeleteAllEntriesTables())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The action if the user want to delete article
        /// </summary>
        /// <param name="RefArticle"> The RefArticle</param>
        /// <returns> The bool if success </returns>
        public bool DeleteArticle(string RefArticle)
        {
            return DaoFurniture.DeleteArticle(RefArticle);
        }

        /// <summary>
        /// The action if the user want to init and set data into DB with xml file
        /// </summary>
        /// <returns> The bool if success </returns>
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

        /// <summary>
        /// The action if the user want to update DB with xml file
        /// </summary>
        /// <returns> The bool if success </returns>
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

        /// <summary>
        /// Check family syntax with distance Levenshtein
        /// </summary>
        /// <param name="FamilyToAdd"> The name of family to add</param>
        /// <returns> The Family if find or null </returns>
        public static Family CheckFamilySyntax(string FamilyToAdd)
        {
            List<Family> ListFamily = GetAllFamily();

            int BestDistance = 255;
            int Temp = 0;

            Family Family = null;

            foreach (Family FamilyEntry in ListFamily)
            {
                Temp = DistanceLevenshtein(FamilyToAdd, FamilyEntry.GetSetFamilyName);

                if (Temp < BestDistance)
                {
                    BestDistance = Temp;
                    Family = FamilyEntry;
                }
            }

            if (BestDistance <= 2)
                return Family;
            else
                return null;
        }

        /// <summary>
        /// Check subFamily syntax with distance Levenshtein
        /// </summary>
        /// <param name="SubFamilyToAdd"> The name of SubFamily to add</param>
        /// <returns> The SubFamily if find or null </returns>
        public static SubFamily CheckSubFamilySyntax(string SubFamilyToAdd)
        {
            List<SubFamily> ListSubFamily = GetAllSubFamily();

            int BestDistance = 255;
            int Temp = 0;

            SubFamily SubFamily = null;

            foreach (SubFamily SubFamilyEntry in ListSubFamily)
            {
                Temp = DistanceLevenshtein(SubFamilyToAdd, SubFamilyEntry.GetSetSubFamilyName);

                if (Temp < BestDistance)
                {
                    BestDistance = Temp;
                    SubFamily = SubFamilyEntry;
                }
            }

            if (BestDistance <= 2)
                return SubFamily;
            else
                return null;
        }

        /// <summary>
        /// Check brand syntax with distance Levenshtein
        /// </summary>
        /// <param name="BrandToAdd"> The name of brand to add</param>
        /// <returns> The Brand if find or null </returns>
        public static Brand CheckBrandSyntax(string BrandToAdd)
        {
            List<Brand> ListBrand = GetAllBrands();

            int BestDistance = 255;
            int Temp = 0;

            Brand Brand = null;

            foreach (Brand BrandEntry in ListBrand)
            {
                Temp = DistanceLevenshtein(BrandToAdd, BrandEntry.GetSetNameBrand);

                if (Temp < BestDistance)
                {
                    BestDistance = Temp;
                    Brand = BrandEntry;
                }
            }

            if (BestDistance <= 2)
                return Brand;
            else
                return null;
        }

        /// <summary>
        /// Create or modify article from the Dialog_SelectXML
        /// </summary>
        /// <param name="Article"> The Article object to add </param>
        public void CreateOrModifyArticleXML(Article Article)
        {
            try
            {
                DaoFurniture.CreateOrModifyArticleXML(Article);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Create or modify article from the Dialog_AddEditArticle
        /// </summary>
        /// <param name="Article"> The Article object to add </param>
        /// <param name="ActioNEdit"> The action wanted by the user, if true it's edit action</param>
        public void CreateOrModifyArticle(Article Article, bool ActionEdit)
        {
            try
            {
                DaoFurniture.CreateOrModifyArticle(Article, ActionEdit);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Add an item to the list view
        /// </summary>
        /// <param name="Article"> The Article object to add </param>
        /// <returns> The ListViewItem </returns>
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

        /// <summary>
        /// Refresh the list view
        /// </summary>
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

        /// <summary>
        /// Update status text
        /// </summary>
        /// <param name="Article"> Object of Article </param>
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

        /// <summary>
        /// Update the progress text
        /// </summary>
        /// <param name="Text"> Object of text </param>
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

        /// <summary>
        /// Get list of all articles
        /// </summary>
        /// <returns> The list of articles </returns>
        public List<Article> GetAllArticles()
        {
            return DaoFurniture.GetAllArticles();
        }

        /// <summary>
        /// Get list of all brands
        /// </summary>
        /// <returns> The list of brands </returns>
        public static List<Brand> GetAllBrands()
        {
            return DaoFurniture.GetAllBrands();
        }

        /// <summary>
        /// Get list of all family
        /// </summary>
        /// <returns> The list of family </returns>
        public static List<Family> GetAllFamily()
        {
            return DaoFurniture.GetAllFamily();
        }

        /// <summary>
        /// Get list of all subFamily
        /// </summary>
        /// <returns> The list of subFamily </returns>
        public static List<SubFamily> GetAllSubFamily()
        {
            return DaoFurniture.GetAllSubFamily();
        }

        /// <summary>
        /// Get list of subFamily from family
        /// </summary>
        /// <param name="Family"> The name of the family </param>
        /// <returns> The list of subFamily </returns>
        public List<SubFamily> GetAllSubFamilyOfFamily(string Family)
        {
            return DaoFurniture.GetAllSubFamilyOfFamily(Family);
        }

        /// <summary>
        /// Get the name of the family of a subFamily
        /// </summary>
        /// <param name="SubFamily"> The name of the subFamily </param>
        /// <returns> The name of the family </returns>
        public string GetFamilyNameOfSubFamily(string SubFamily)
        {
            int IdFamilyName = DaoFurniture.GetFamilyIdOfSubFamily(SubFamily);

            return DaoFurniture.GetFamilyName(IdFamilyName);
        }

        /// <summary>
        /// Compute the distance between tow string
        /// </summary>
        /// <param name="s"> The first string </param>
        /// <param name="t">The second string </param>
        /// <returns> Distance of 2 strings </returns>
        private static int DistanceLevenshtein(string s, string t)
        {
            s = s.ToLower();
            t = t.ToLower();

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0)
                return m;

            if (m == 0)
                return n;

            for (int i = 0; i <= n; d[i, 0] = i++) { }
            for (int j = 0; j <= m; d[0, j] = j++) { }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercure.Controller;
using Mercure.View;

namespace Mercure
{
    public partial class MainWindow : Form
    {
        public static MainWindow MainWindowForm;
        public MainWindow()
        {
            InitializeComponent();
            MainWindowForm = this;

            ListViewArticles.Columns.Add("RefArticle");
            ListViewArticles.Columns.Add("Description");
            ListViewArticles.Columns.Add("Brand");
            ListViewArticles.Columns.Add("SubFamily");
            ListViewArticles.Columns.Add("Price");
            ListViewArticles.Columns.Add("Quantity");

            ControllerFurniture ControllerFurniture = new ControllerFurniture();
            ControllerFurniture.RefreshListView();
        }

        private void openXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog_SelectionXML dialog_SelectionXML = new Dialog_SelectionXML();
            dialog_SelectionXML.Show();
        }

        private void ListViewArticles_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewArticles.Sort();
            this.ListViewArticles.ListViewItemSorter = new ListViewItemComparator(e.Column, ListViewArticles.Sorting);
        }
    }
}

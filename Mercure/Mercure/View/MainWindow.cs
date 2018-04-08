using System;
using System.Windows.Forms;
using Mercure.Controller;
using Mercure.View;
using System.Drawing;

namespace Mercure
{
    public partial class MainWindow : Form
    {
        public static MainWindow MainWindowForm;
        private ControllerFurniture ControllerFurniture;

        public MainWindow()
        {
            InitializeComponent();
            MainWindowForm = this;

            // Initialise the ListView
            ListViewArticles.Columns.Add("RefArticle");
            ListViewArticles.Columns.Add("Description");
            ListViewArticles.Columns.Add("Brand");
            ListViewArticles.Columns.Add("SubFamily");
            ListViewArticles.Columns.Add("Price");
            ListViewArticles.Columns.Add("Quantity");

            ControllerFurniture = new ControllerFurniture();
            ControllerFurniture.RefreshListView();
        }

        private void openXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog_SelectionXML Dialog_SelectionXML = new Dialog_SelectionXML();
            Dialog_SelectionXML.Show();
        }

        private void ListViewArticles_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewArticles.Sort();
            this.ListViewArticles.ListViewItemSorter = new ListViewItemComparator(e.Column, ListViewArticles.Sorting);
        }

        private void SetTextBox()
        {
            ListView.SelectedListViewItemCollection breakfast = this.ListViewArticles.SelectedItems;

            string RefArticle = null;
            string Description = null;
            string Brand = null;
            string Family = null;
            string SubFamily = null;

            double Price = 0.0;
            int Quantity = 0;

            foreach (ListViewItem item in breakfast)
            {
                RefArticle = item.SubItems[0].Text;
                Description = item.SubItems[1].Text;
                Brand = item.SubItems[2].Text;
                SubFamily = item.SubItems[3].Text;
                Family = ControllerFurniture.GetFamilyNameOfSubFamily(SubFamily);
                Price = Double.Parse(item.SubItems[4].Text);
                Quantity = Int32.Parse(item.SubItems[5].Text);
            }

            Dialog_AddEditWindow AddEditWindow = new Dialog_AddEditWindow(RefArticle, Description, Brand, Family, SubFamily, Price, Quantity);
            AddEditWindow.Show();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                ControllerFurniture.RefreshListView();
                MessageBox.Show("List view refreshed !");
            }
        }

        private void ListViewArticles_DoubleClick(object sender, EventArgs e)
        {
            ModifyArticle();
        }

        private void ListViewArticles_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //String fileName = filesList.SelectedItems[0].Text; //获取选中文件名  
                Point MousePosition = new Point(e.X, e.Y);
                ContextMenuStrip.Show(ListViewArticles, MousePosition);
            }  
        }

        private void modifyThisAritcleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyArticle();
        }

        private void ModifyArticle()
        {
            string RefArticle = this.ListViewArticles.SelectedItems[0].Text;
            string Description = this.ListViewArticles.SelectedItems[0].SubItems[1].Text;
            string Brand = this.ListViewArticles.SelectedItems[0].SubItems[2].Text;
            string SubFamily = this.ListViewArticles.SelectedItems[0].SubItems[3].Text;
            double Price = double.Parse(this.ListViewArticles.SelectedItems[0].SubItems[4].Text);
            int Quantity = int.Parse(this.ListViewArticles.SelectedItems[0].SubItems[5].Text);
            Dialog_AddEditWindow Dialog_AddEditWindow =
                new Dialog_AddEditWindow(RefArticle, Description, Brand, "Family", SubFamily, Price, Quantity);
            Dialog_AddEditWindow.Show();
        }
    }
}

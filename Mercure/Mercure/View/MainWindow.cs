using System;
using System.Windows.Forms;
using Mercure.Controller;
using Mercure.View;

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

        private void ListViewArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTextBox();

            // Output the price to TextBox1.
            //TextBox.Text = price.ToString();
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

            AddEditWindow AddEditWindow = new AddEditWindow(RefArticle, Description, Brand, Family, SubFamily, Price, Quantity);
            AddEditWindow.Show();
        }
    }
}

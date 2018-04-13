using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mercure.View
{
    partial class Dialog_Brand : Dialog_Basic
    {
        public Dialog_Brand()
        {
            InitializeComponent();
            this.Size = new Size(500, 400);
            // Initialise the ListView
            ListViewBasic.Columns.Add("RefBrand");
            ListViewBasic.Columns.Add("Name");

            ControllerManagement.RefreshListViewBrand();
        }

        protected override void ListViewBasic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                ControllerManagement.RefreshListViewBrand();
                MessageBox.Show("List view refreshed !");
            }
        }

        protected override void Delete()
        {
            if (ListViewBasic.SelectedItems.Count != 0)
            {
                // Get RefBrand from the ListView
                int RefBrand = int.Parse(ListViewBasic.SelectedItems[0].Text);

                if (ControllerManagement.DeleteBrand(RefBrand))
                {
                    ControllerManagement.RefreshListViewBrand();
                    MessageBox.Show("Succesfully deleted the brand !");
                }
                else
                {
                    MessageBox.Show("Error : Fail to delete the brand ! ");
                }
            }
            else
            {
                MessageBox.Show("Error : Choose a brand before trying  to delete it !");
            }
        }

        protected override void Add()
        {
            Dialog_AddEditBrand Dialog_AddEditBrand = new Dialog_AddEditBrand();
            Dialog_AddEditBrand.ShowDialog(this);
        }

        protected override void Modify()
        {
            int RefBrand = int.Parse(this.ListViewBasic.SelectedItems[0].Text);
            string NameBrand = this.ListViewBasic.SelectedItems[0].SubItems[1].Text;
            Dialog_AddEditBrand Dialog_AddEditBrand = new Dialog_AddEditBrand(RefBrand, NameBrand);
            Dialog_AddEditBrand.ShowDialog(this);
        }
    }
}

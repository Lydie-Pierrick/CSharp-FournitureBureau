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
    partial class Dialog_Family : Dialog_Basic
    {
        public Dialog_Family()
        {
            InitializeComponent();
            this.Size = new Size(500, 400);

            ListViewBasic.Columns.Add("RefFamily");
            ListViewBasic.Columns.Add("Name");

            ControllerManagement.RefreshListViewFamily();
        }

        protected new void ListViewBasic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                ControllerManagement.RefreshListViewFamily();
                MessageBox.Show("List view refreshed !");
            }
        }

        protected override void Delete()
        {
            if (ListViewBasic.SelectedItems.Count != 0)
            {
                // Get RefFamily from the ListView
                int RefFamily = int.Parse(ListViewBasic.SelectedItems[0].Text);

                if (ControllerManagement.DeleteFamily(RefFamily))
                {
                    ControllerManagement.RefreshListViewFamily();
                    MessageBox.Show("Succesfully deleted the Family !");
                }
                else
                {
                    MessageBox.Show("Error : Fail to delete the Family ! ");
                }
            }
            else
            {
                MessageBox.Show("Error : Choose a Family before trying  to delete it !");
            }
        }

        protected override void Add()
        {
            Dialog_AddEditFamily Dialog_AddEditFamily = new Dialog_AddEditFamily();
            Dialog_AddEditFamily.ShowDialog(this);
        }

        protected override void Modify()
        {
            int RefFamily = int.Parse(this.ListViewBasic.SelectedItems[0].Text);
            string NameFamily = this.ListViewBasic.SelectedItems[0].SubItems[1].Text;
            Dialog_AddEditFamily Dialog_AddEditFamily = new Dialog_AddEditFamily(RefFamily, NameFamily);
            Dialog_AddEditFamily.ShowDialog(this);
        }
    }
}

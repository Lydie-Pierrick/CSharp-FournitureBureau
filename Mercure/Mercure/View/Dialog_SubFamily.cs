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
    partial class Dialog_SubFamily : Dialog_Basic
    {
        public Dialog_SubFamily()
        {
            InitializeComponent();
            this.Size = new Size(500, 400);

            ListViewBasic.Columns.Add("RefSubFamily");
            ListViewBasic.Columns.Add("RefFamily");
            ListViewBasic.Columns.Add("Name");

            ControllerManagement.RefreshListViewSubFamily();
        }

        protected override void ListViewBasic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                ControllerManagement.RefreshListViewSubFamily();
                MessageBox.Show("List view refreshed !");
            }

            if (e.KeyData == Keys.Delete)
            {
                Delete();
            }
        }

        protected override void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add();
        }

        protected override void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modify();
        }

        protected override void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        protected override void Delete()
        {
            if (ListViewBasic.SelectedItems.Count != 0)
            {
                // Get RefSubFamily from the ListView
                int RefSubFamily = int.Parse(ListViewBasic.SelectedItems[0].Text);

                if (ControllerManagement.DeleteSubFamily(RefSubFamily))
                {
                    ControllerManagement.RefreshListViewSubFamily();
                    MessageBox.Show("Succesfully deleted the SubFamily !");
                }
                else
                {
                    MessageBox.Show("Error : Fail to delete the SubFamily ! ");
                }
            }
            else
            {
                MessageBox.Show("Error : Choose a SubFamily before trying  to delete it !");
            }
        }

        protected override void Add()
        {
            Dialog_AddEditSubFamily Dialog_AddEditSubFamily = new Dialog_AddEditSubFamily();
            Dialog_AddEditSubFamily.ShowDialog(this);
        }

        protected override void Modify()
        {
            int RefSubFamily = int.Parse(this.ListViewBasic.SelectedItems[0].Text);
            string NameFamily = this.ListViewBasic.SelectedItems[0].SubItems[1].Text;
            string NameSubFamily = this.ListViewBasic.SelectedItems[0].SubItems[2].Text;
            Dialog_AddEditSubFamily Dialog_AddEditSubFamily = 
                        new Dialog_AddEditSubFamily(RefSubFamily, NameFamily, NameSubFamily);
            Dialog_AddEditSubFamily.ShowDialog(this);
        }
    }
}

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

            if (e.KeyData == Keys.Delete)
            {
                //DeleteBrand();
                MessageBox.Show("Successfully deleted the brand !");
            }
        }

        protected override void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully added the brand !");
        }

        protected override void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully modified the brand !");
        }

        protected override void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DeleteBrand();
            MessageBox.Show("Successfully deleted the brand !");
        }
    }
}

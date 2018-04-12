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

        protected override void ListViewBasic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                ControllerManagement.RefreshListViewFamily();
                MessageBox.Show("List view refreshed !");
            }

            if (e.KeyData == Keys.Delete)
            {
                //DeleteBrand();
                MessageBox.Show("Successfully deleted the family !");
            }
        }

        protected override void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully added the family !");
        }

        protected override void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully modified the family !");
        }

        protected override void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DeleteFamily();
            MessageBox.Show("Successfully deleted the family !");
        }
    }
}

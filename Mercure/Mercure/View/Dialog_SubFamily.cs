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
                //DeleteSubFamily();
                MessageBox.Show("Successfully deleted the subfamily !");
            }
        }

        protected override void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully added the subfamily !");
        }

        protected override void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully modified the subfamily !");
        }

        protected override void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DeleteSubfamily();
            MessageBox.Show("Successfully deleted the subfamily !");
        }
    }
}

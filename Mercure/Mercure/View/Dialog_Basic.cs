using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mercure.Controller;

namespace Mercure.View
{
    partial class Dialog_Basic : Form
    {
        public static Dialog_Basic DialogBasic;
        protected ControllerManagement ControllerManagement;
        public static int ModifyOrAdd = -1;
        protected static bool IsChoosen = false;

        public Dialog_Basic()
        {
            InitializeComponent();
            DialogBasic = this;
            ListViewBasic.GridLines = true;
            ListViewBasic.FullRowSelect = true;
            //ListViewBrands.View = View.Details;

            ControllerManagement = new ControllerManagement();
        }

        protected virtual void ListViewBasic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                Delete();
            }

            if (e.KeyData == Keys.Enter)
            {
                Modify();
            }
        }

        private void ListViewBasic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point MousePosition = new Point(e.X, e.Y);
                ContextMenuStrip.Show(ListViewBasic, MousePosition);
            }  
        }

        protected  void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add();
        }

        protected void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modify();
        }

        protected void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        protected void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void ListViewBasic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Modify();
        }

        protected virtual void Delete()
        {
        }

        protected virtual void Add()
        {
            ModifyOrAdd = 1;
        }

        protected virtual void Modify()
        {
            ModifyOrAdd = 0;
            if (ListViewBasic.SelectedItems.Count == 0)
            {
                MessageBox.Show("Error : Choose an item before trying  to modify it !");
                IsChoosen = false;
            }
            else
            {
                IsChoosen = true;
            }
        }

        protected virtual void ListViewBasic_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewBasic.Sort();
            this.ListViewBasic.ListViewItemSorter = new ListViewItemComparator(e.Column, ListViewBasic.Sorting);
        }
    }
}

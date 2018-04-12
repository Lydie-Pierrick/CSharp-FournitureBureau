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
        }

        private void ListViewBasic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point MousePosition = new Point(e.X, e.Y);
                ContextMenuStrip.Show(ListViewBasic, MousePosition);
            }  
        }

        protected virtual void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        protected virtual void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        protected virtual void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}

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
    public partial class Dialog_AddEditFamily : Form
    {
        private ControllerManagement ControllerManagement;

        public Dialog_AddEditFamily()
        {
            InitializeComponent();
            ControllerManagement = new ControllerManagement();
        }

        public Dialog_AddEditFamily(int RefFamily, string NameFamily)
        {
            InitializeComponent();
            TextRefFamily.Text = RefFamily.ToString();
            TextBox.Text = NameFamily;
            ControllerManagement = new ControllerManagement();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ControllerManagement.InsertFamily(TextBox.Text);
                ControllerManagement.RefreshListViewFamily();

                if (MessageBox.Show("Operation accepted !") == DialogResult.OK)
                {
                    Close();
                }
            }
            catch (Exception Exception)
            {
                MessageBox.Show("Error during the operation ! " + Exception.Message);
            }
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

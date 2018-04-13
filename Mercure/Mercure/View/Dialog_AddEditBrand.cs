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
    public partial class Dialog_AddEditBrand : Form
    {
        private ControllerManagement ControllerManagement;

        public Dialog_AddEditBrand()
        {
            InitializeComponent();
            ControllerManagement =new ControllerManagement();
        }

        public Dialog_AddEditBrand(int RefBrand, string NameBrand)
        {
            InitializeComponent();
            TextRefBrand.Text = RefBrand.ToString();
            TextBox.Text = NameBrand;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ControllerManagement.InsertBrand(TextBox.Text);
                ControllerManagement.RefreshListViewBrand();

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

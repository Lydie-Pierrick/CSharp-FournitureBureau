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
            ControllerManagement = new ControllerManagement();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Revoir
            try
            {
                if (Dialog_Basic.ModifyOrAdd == 0)
                {
                    int RefBrand = int.Parse(TextRefBrand.Text);
                    string BrandName =  TextBox.Text;

                    if (!ControllerManagement.ModifyBrand(RefBrand, BrandName))
                    {
                        MessageBox.Show("Fail to modify the brand ! ");
                    }
                    else
                    {
                        if (MessageBox.Show("Successfully modified the brand !") == DialogResult.OK)
                        {
                            Close();
                        }
                    }
                }
                else if (Dialog_Basic.ModifyOrAdd == 1)
                {
                    ControllerManagement.AddBrand(TextBox.Text);

                    if (MessageBox.Show("Successfully added the brand !") == DialogResult.OK)
                    {
                        Close();
                    }
                }

                ControllerManagement.RefreshListViewBrand();
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

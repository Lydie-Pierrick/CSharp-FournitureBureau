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
                if (Dialog_Basic.ModifyOrAdd == 0)
                {
                    if (!ControllerManagement.ModifyFamily(int.Parse(TextRefFamily.Text), TextBox.Text))
                    {
                        MessageBox.Show("Fail to modify the family ! ");
                    }
                    else
                    {
                        if (MessageBox.Show("Successfully modified the family !") == DialogResult.OK)
                        {
                            Close();
                        }
                    }
                }
                else if (Dialog_Basic.ModifyOrAdd == 1)
                {
                    ControllerManagement.AddFamily(TextBox.Text);

                    if (MessageBox.Show("Successfully added the family !") == DialogResult.OK)
                    {
                        Close();
                    }
                }
                
                ControllerManagement.RefreshListViewFamily();

                
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

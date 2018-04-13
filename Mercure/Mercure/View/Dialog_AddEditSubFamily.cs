using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mercure.Controller;
using Mercure.Model;

namespace Mercure.View
{
    public partial class Dialog_AddEditSubFamily : Form
    {
        private ControllerManagement ControllerManagement;
        public Dialog_AddEditSubFamily()
        {
            InitializeComponent();
            ControllerManagement = new ControllerManagement();

            SetComboBox();
        }

        public Dialog_AddEditSubFamily(int RefSubFamily, string NameFamily, string NameSubFamily)
        {
            InitializeComponent();           

            TextRefSubFamily.Text = RefSubFamily.ToString();
            SetComboBox();

            Combobox.SelectedIndex = Combobox.FindStringExact(NameFamily);
            TextBox.Text = NameSubFamily;
            ControllerManagement = new ControllerManagement();
        }

        void SetComboBox()
        {
            Combobox.Items.Clear();

            List<Family> ListFamilies = ControllerFurniture.GetAllFamily();

            foreach (Family Family in ListFamilies)
            {
                string FamilyName = Family.GetSetFamilyName;
                Combobox.Items.Add(FamilyName);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dialog_Basic.ModifyOrAdd == 0)
                {
                    if (!ControllerManagement.ModifySubFamily(int.Parse(TextRefSubFamily.Text), TextBox.Text, Combobox.Items.ToString()))
                    {
                        MessageBox.Show("Fail to modify the subfamily ! ");
                    }
                    else
                    {
                        if (MessageBox.Show("Successfully modified the subfamily !") == DialogResult.OK)
                        {
                            Close();
                        }
                    }
                    
                }
                else if (Dialog_Basic.ModifyOrAdd == 1)
                {
                    ControllerManagement.AddSubFamily(TextBox.Text, Combobox.SelectedItem.ToString());

                    if (MessageBox.Show("Successfully added the brand !") == DialogResult.OK)
                    {
                      Mercure.MainWindow.StatusSQL_Label.Text = "Operation on subFamily.";
                      Close();
                    }
                }
                
                ControllerManagement.RefreshListViewSubFamily();
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

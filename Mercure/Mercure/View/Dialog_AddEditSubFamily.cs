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
                ControllerManagement.InsertSubFamily(TextBox.Text, Combobox.SelectedIndex.ToString());
                ControllerManagement.RefreshListViewSubFamily();

                if (MessageBox.Show("Operation accepted !") == DialogResult.OK)
                {
                    Mercure.MainWindow.StatusSQL_Label.Text = "Operation on subFamily.";
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

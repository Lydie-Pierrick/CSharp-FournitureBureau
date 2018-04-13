using System;
using System.Windows.Forms;
using Mercure.Controller;
using Mercure.Model;
using System.Collections.Generic;

namespace Mercure.View
{
    public partial class Dialog_AddEditArticle : Form
    {
        private ControllerFurniture ControllerFurniture;

        public Dialog_AddEditArticle()
        {
            InitializeComponent();
            ControllerFurniture = new ControllerFurniture();
            InitTextBox();
        }

        public Dialog_AddEditArticle(string RefArticle, string Description, string Brand, string Family, string SubFamily, double Price, int Quantity)
        {
            InitializeComponent();
            ControllerFurniture = new ControllerFurniture();
            InitTextBox();
            TextBoxRefArticle.Enabled = false;

            TextBoxRefArticle.Text = RefArticle;
            TextBoxDescription.Text = Description;
            ComboBoxBrand.SelectedIndex = ComboBoxBrand.FindStringExact(Brand);

            ComboBoxFamily.SelectedIndex = ComboBoxFamily.FindStringExact(Family);
            ComboBoxSubFamily.SelectedIndex = ComboBoxSubFamily.FindStringExact(SubFamily);
            TextBoxPrice.Text = Price.ToString();
            TextBoxQuantity.Text = Quantity.ToString();
        }

        private void InitTextBox()
        {
            // Init Brand
            List<Brand> ListBrand = ControllerFurniture.GetAllBrands();

            foreach (Brand Brand in ListBrand)
            {
                ComboBoxBrand.Items.Add(Brand);
            }

            // Init Family
            List<Family> ListFamily = ControllerFurniture.GetAllFamily();

            foreach (Family Family in ListFamily)
            {
                ComboBoxFamily.Items.Add(Family);
            }
        }

        private void InitTextBoxSubFamily()
        {
            // Init SubFamily
            List<SubFamily> ListSubFamily = ControllerFurniture.GetAllSubFamilyOfFamily(ComboBoxFamily.Text);

            ComboBoxSubFamily.Items.Clear();
            ComboBoxSubFamily.ResetText();
            ComboBoxSubFamily.SelectedIndex = -1;

            foreach (SubFamily SubFamily in ListSubFamily)
            {
                ComboBoxSubFamily.Items.Add(SubFamily);
            }

            ComboBoxSubFamily.SelectedIndex = 0;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {           
            try
            {
                Article Article = new Article(TextBoxRefArticle.Text, TextBoxDescription.Text, ComboBoxFamily.Text, ComboBoxSubFamily.Text, ComboBoxBrand.Text, TextBoxPrice.Text, int.Parse(TextBoxQuantity.Text));

                if (TextBoxRefArticle.Enabled == true)
                {
                    ControllerFurniture.CreateOrModifyArticle(Article, false);
                }
                else
                {
                    ControllerFurniture.CreateOrModifyArticle(Article, true);
                }

                ControllerFurniture.RefreshListView();

                if (MessageBox.Show("Successfully modified !") == DialogResult.OK)
                {
                    Close();
                }
            }
            catch(Exception Exception)
            {
                MessageBox.Show("Error during the modification ! " + Exception.Message);
            }
        }

        private void ComboBoxFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitTextBoxSubFamily();
        }
    }
}

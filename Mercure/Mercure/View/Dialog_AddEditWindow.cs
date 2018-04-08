using System;
using System.Windows.Forms;
using Mercure.Controller;
using Mercure.Model;
using System.Collections.Generic;

namespace Mercure.View
{
    public partial class Dialog_AddEditWindow : Form
    {
        private ControllerFurniture ControllerFurniture;

        public Dialog_AddEditWindow()
        {
            InitializeComponent();
            ControllerFurniture = new ControllerFurniture();
            InitTextBox();
        }

        public Dialog_AddEditWindow(string RefArticle, string Description, string Brand, string Family, string SubFamily, double Price, int Quantity)
        {
            InitializeComponent();
            ControllerFurniture = new ControllerFurniture();
            InitTextBox();

            TextBoxRefArticle.Text = RefArticle;
            TextBoxDescription.Text = Description;
            ComboBoxBrand.SelectedIndex = ComboBoxBrand.FindStringExact(Brand);
            ComboBoxFamily.SelectedIndex = ComboBoxFamily.FindStringExact(Family);
            ComboBoxSubFamily.SelectedIndex = ComboBoxSubFamily.FindStringExact(SubFamily);
            TextBoxPrice.Text = Price.ToString();
            TextBoxQuantity.Text = Quantity.ToString();

            GetFamily(SubFamily);
        }

        private void InitTextBox()
        {
            // Init Brand
            List<Brand> ListBrand = ControllerFurniture.GetAllBrands();

            foreach (Brand Brand in ListBrand)
            {
                ComboBoxBrand.Items.Add(Brand);
            }

            ComboBoxBrand.SelectedIndex = 0;

            // Init Family
            List<Family> ListFamily = ControllerFurniture.GetAllFamily();

            foreach (Family Family in ListFamily)
            {
                ComboBoxFamily.Items.Add(Family);
            }

            ComboBoxFamily.SelectedIndex = 0;

            // Init SubFamily
            List<SubFamily> ListSubFamily = ControllerFurniture.GetAllSubFamily();

            foreach (SubFamily SubFamily in ListSubFamily)
            {
                ComboBoxSubFamily.Items.Add(SubFamily);
            }

            ComboBoxSubFamily.SelectedIndex = 0;
        }

        private void GetFamily(string SubFamily)
        {
            String Family;
            //Family = 
            //ComboBoxFamily.SelectedIndex = ComboBoxSubFamily.FindStringExact(Family);
        }
    }
}

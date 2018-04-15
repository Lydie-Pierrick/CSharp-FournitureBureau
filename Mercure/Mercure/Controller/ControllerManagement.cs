using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mercure.Model;
using Mercure.DAO;
using Mercure.View;

namespace Mercure.Controller
{
    class ControllerManagement
    {
        private DaoFurniture DaoFurniture;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ControllerManagement()
        {
            DaoFurniture = new DaoFurniture();
        }

        /// <summary>
        /// Add a brand to ListView
        /// </summary>
        /// <param name="Brand"> A Brand object </param>
        /// <returns> A line of the information of a brand </returns>
        public ListViewItem AddBrandToListView(Brand Brand)
        {
            ListViewItem Line = new ListViewItem(Brand.GetSetIdBrand.ToString());
            Line.SubItems.Add(Brand.GetSetNameBrand);

            return Line;
        }

        /// <summary>
        /// Refresh the brand ListView
        /// </summary>
        public void RefreshListViewBrand()
        {
            int NumBrand;
            List<Brand> ListBrands = DaoFurniture.GetAllBrands();

            Dialog_Basic.DialogBasic.ListViewBasic.Items.Clear();

            // Show all the data on the ListView
            for (NumBrand = 0; NumBrand < ListBrands.Count; NumBrand++)
            {
                ListViewItem Line = AddBrandToListView(ListBrands[NumBrand]);
                Dialog_Basic.DialogBasic.ListViewBasic.Items.Add(Line);
            }

            // Autoresize widths of columns
            foreach (ColumnHeader ColumnHeader in  Dialog_Basic.DialogBasic.ListViewBasic.Columns)
            {
                // Width changes with the texts as well as headers
                ColumnHeader.Width = -2;
            }
        }

        /// <summary>
        /// Add a family to ListView
        /// </summary>
        /// <param name="Family"> A Family object </param>
        /// <returns> A line of the information of a family </returns>
        public ListViewItem AddFamilyToListView(Family Family)
        {
            ListViewItem Line = new ListViewItem(Family.GetSetIdFamily.ToString());
            Line.SubItems.Add(Family.GetSetFamilyName);

            return Line;
        }


        /// <summary>
        /// Refresh the family ListView
        /// </summary>
        public void RefreshListViewFamily()
        {
            int NumFamily;
            List<Family> ListFamilies = DaoFurniture.GetAllFamily();

            Dialog_Basic.DialogBasic.ListViewBasic.Items.Clear();

            // Show all the data on the ListView
            for (NumFamily = 0; NumFamily < ListFamilies.Count; NumFamily++)
            {
                ListViewItem Line = AddFamilyToListView(ListFamilies[NumFamily]);
                Dialog_Basic.DialogBasic.ListViewBasic.Items.Add(Line);
            }

            // Autoresize widths of columns
            foreach (ColumnHeader ColumnHeader in Dialog_Basic.DialogBasic.ListViewBasic.Columns)
            {
                // Width changes with the texts as well as headers
                ColumnHeader.Width = -2;
            }
        }

        /// <summary>
        /// Add a subfamily to ListView
        /// </summary>
        /// <param name="Brand"> A subfamily object </param>
        /// <returns> A line of the information of a subfamily </returns>
        public ListViewItem AddSubFamilyToListView(SubFamily SubFamily)
        {
            string SubFamilyName = SubFamily.GetSetSubFamilyName;
            int IdFamily = DaoFurniture.GetFamilyIdOfSubFamily(SubFamilyName);
            string FamilyName = DaoFurniture.GetFamilyName(IdFamily);

            ListViewItem Line = new ListViewItem(SubFamily.GetSetIdSubFamily.ToString());
            Line.SubItems.Add(FamilyName);
            Line.SubItems.Add(SubFamilyName);

            return Line;
        }

        /// <summary>
        /// Refresh the subfamily ListView
        /// </summary>
        public void RefreshListViewSubFamily()
        {
            int NumSubFamily;
            List<SubFamily> ListSubFamilies = DaoFurniture.GetAllSubFamily();

            Dialog_Basic.DialogBasic.ListViewBasic.Items.Clear();

            // Show all the data on the ListView
            for (NumSubFamily = 0; NumSubFamily < ListSubFamilies.Count; NumSubFamily++)
            {
                ListViewItem Line = AddSubFamilyToListView(ListSubFamilies[NumSubFamily]);
                Dialog_Basic.DialogBasic.ListViewBasic.Items.Add(Line);
            }

            // Autoresize widths of columns
            foreach (ColumnHeader ColumnHeader in Dialog_Basic.DialogBasic.ListViewBasic.Columns)
            {
                // Width changes with the texts as well as headers
                ColumnHeader.Width = -2;
            }
        }

        /// <summary>
        /// Delete a brand from DB
        /// </summary>
        /// <param name="RefBrand">Reference of brand </param>
        /// <returns> The result of  DaoFurniture.DeleteBrand(RefBrand)</returns>
        public bool DeleteBrand(int RefBrand)
        {
            return DaoFurniture.DeleteBrand(RefBrand);
        }

        /// <summary>
        /// Delete a family from DB
        /// </summary>
        /// <param name="RefFamily">Reference of family </param>
        /// <returns> The result of  DaoFurniture.DeleteFamily(RefFamily)</returns>
        public bool DeleteFamily(int RefFamily)
        {
            return DaoFurniture.DeleteFamily(RefFamily);
        }

        /// <summary>
        /// Delete a subfamily from DB
        /// </summary>
        /// <param name="RefSubFamily">Reference of subfamily </param>
        /// <returns> The result of  DaoFurniture.DeleteSubFamily(RefSubFamily)</returns>
        public bool DeleteSubFamily(int RefSubfamily)
        {
            return DaoFurniture.DeleteSubFamily(RefSubfamily);
        }

        /// <summary>
        /// Add a brand from DB
        /// </summary>
        /// <param name="BrandName"> Brand name </param>
        public void AddBrand(string BrandName)
        {
            DaoFurniture.GetOrCreateBrand(BrandName);
        }

        /// <summary>
        /// Add a family from DB
        /// </summary>
        /// <param name="FamilyName"> Family name </param>
        public void AddFamily(string FamilyName)
        {
            DaoFurniture. GetOrCreateFamily(FamilyName);
        }

        /// <summary>
        /// Add a subfamily from DB
        /// </summary>
        /// <param name="SubFamilyName"> Subfamily name </param>
        /// <param name="FamilyName"> Family name </param>
        public void AddSubFamily(string SubFamilyName, string FamilyName)
        {
            DaoFurniture.GetOrCreateSubFamily(SubFamilyName, FamilyName);
        }

        /// <summary>
        /// Modify a brand in DB
        /// </summary>
        /// <param name="RefBrand">Reference of brand </param>
        /// <param name="BrandName"> Brand name </param>
        /// <returns> The result of  DaoFurniture.ModifyBrand(RefBrand, BrandName)</returns>
        public bool ModifyBrand(int RefBrand, string BrandName)
        {
            return DaoFurniture.ModifyBrand(RefBrand, BrandName);
        }

        /// <summary>
        /// Modify a family in DB
        /// </summary>
        /// <param name="RefFamily">Reference of family </param>
        /// <param name="FamilyName"> Family name </param>
        /// <returns> The result of  DaoFurniture.ModifyFamily(RefFamily, FamilyName)</returns>
        public bool ModifyFamily(int RefFamily, string FamilyName)
        {
            return DaoFurniture.ModifyFamily(RefFamily, FamilyName);
        }

        /// <summary>
        /// Modify a subfamily in DB
        /// </summary>
        /// <param name="RefSubFamily">Reference of subfamily </param>
        /// <param name="SubFamilyName"> Subfamily name </param>
        /// <param name="FamilyName"> Family name </param>
        /// <returns> The result of  DaoFurniture.ModifySubFamily(RefSubFamily, SubFamilyName, RefFamily)</returns>
        public bool ModifySubFamily(int RefSubFamily, string SubFamilyName, string FamilyName)
        {
            int RefFamily = DaoFurniture.GetFamilyIdByName(FamilyName);
            if (RefFamily == 0)
                return false;
            return DaoFurniture.ModifySubFamily(RefSubFamily, SubFamilyName, RefFamily);
        }
    }
}

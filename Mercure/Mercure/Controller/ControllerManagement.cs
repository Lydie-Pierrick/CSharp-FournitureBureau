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

        public ControllerManagement()
        {
            DaoFurniture = new DaoFurniture();
        }

        public ListViewItem AddBrandToListView(Brand Brand)
        {
            ListViewItem Line = new ListViewItem(Brand.GetSetIdBrand.ToString());
            Line.SubItems.Add(Brand.GetSetNameBrand);

            return Line;
        }

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

        public ListViewItem AddFamilyToListView(Family Family)
        {
            ListViewItem Line = new ListViewItem(Family.GetSetIdFamily.ToString());
            Line.SubItems.Add(Family.GetSetFamilyName);

            return Line;
        }

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

        public bool DeleteBrand(int RefBrand)
        {
            return DaoFurniture.DeleteBrand(RefBrand);
        }

        public bool DeleteFamily(int RefFamily)
        {
            return DaoFurniture.DeleteFamily(RefFamily);
        }

        public bool DeleteSubFamily(int RefSubfamily)
        {
            return DaoFurniture.DeleteSubFamily(RefSubfamily);
        }

        public bool InsertBrand(string BrandName)
        {
            if (DaoFurniture.GetOrCreateBrand(BrandName) != 0)
                return true;
            else
                return false;
        }
       
        public bool InsertFamily(string FamilyName)
        {
            if (DaoFurniture. GetOrCreateFamily(FamilyName) != 0)
                return true;
            else
                return false;
        }

        public bool InsertSubFamily(string SubFamilyName, string FamilyName)
        {
            if (DaoFurniture.GetOrCreateSubFamily(SubFamilyName, FamilyName) != 0)
                return true;
            else
                return false;
        }
    }
}

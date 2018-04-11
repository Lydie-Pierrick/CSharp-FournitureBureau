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
    public partial class Dialog_Brand : Form
    {
        public Dialog_Brand()
        {
            InitializeComponent();

            // Initialise the ListView
            ListViewBrands.Columns.Add("RefBrand");
            ListViewBrands.Columns.Add("Name");

            ControllerManagement ControllerManagement = new ControllerManagement();
            ControllerManagement.RefreshListViewBrand();
        }
    }
}

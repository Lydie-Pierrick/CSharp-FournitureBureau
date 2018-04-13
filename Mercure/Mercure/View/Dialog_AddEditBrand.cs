using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mercure.View
{
    public partial class Dialog_AddEditBrand : Form
    {
        public Dialog_AddEditBrand()
        {
            InitializeComponent();
        }

        public Dialog_AddEditBrand(int RefBrand, string NameBrand)
        {
            InitializeComponent();
            TextRefBrand.Text = RefBrand.ToString();
            TextBox.Text = NameBrand;
        }
    }
}

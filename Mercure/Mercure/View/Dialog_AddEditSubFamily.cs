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
    public partial class Dialog_AddEditSubFamily : Form
    {
        public Dialog_AddEditSubFamily()
        {
            InitializeComponent();
        }

        public Dialog_AddEditSubFamily(int RefSubFamily, string NameFamily, string NameSubFamily)
        {
            InitializeComponent();
            TextRefSubFamily.Text = RefSubFamily.ToString();
            Combobox.SelectedIndex = Combobox.FindStringExact(NameFamily);
            TextBox.Text = NameSubFamily;
        }
    }
}

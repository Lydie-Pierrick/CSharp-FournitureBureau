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
    public partial class Dialog_AddEditFamily : Form
    {
        public Dialog_AddEditFamily()
        {
            InitializeComponent();
        }

        public Dialog_AddEditFamily(int RefFamily, string NameFamily)
        {
            InitializeComponent();
            TextRefFamily.Text = RefFamily.ToString();
            TextBox.Text = NameFamily;
        }
    }
}

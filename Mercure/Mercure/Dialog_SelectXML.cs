using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mercure
{
    public partial class Dialog_SelectionXML : Form
    {
        public Dialog_SelectionXML()
        {
            InitializeComponent();
        }

        private void Btn_BrowseXML_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(OpenFileDialog.FileName);
                // faire qqch
                sr.Close();
            }

            TxtBox_PathXML.Text = OpenFileDialog.FileName;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SQLite;
using Mercure.Controller;

namespace Mercure
{
    public partial class Dialog_SelectionXML : Form
    {
        private ControllerFurniture ControllerFurniture;

        public Dialog_SelectionXML()
        {
            InitializeComponent();
            ControllerFurniture = new ControllerFurniture();
        }

        private void Btn_BrowseXML_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader StreamReader = new System.IO.StreamReader(OpenFileDialog.FileName);

                TxtBox_PathXML.Text = OpenFileDialog.FileName;

                StreamReader.Close();
            }
        }

        private void Btn_ImportXML_Click(object sender, EventArgs e)
        {
            ControllerFurniture.GetterSetterPathXML = TxtBox_PathXML.Text;

            if (string.IsNullOrWhiteSpace(ControllerFurniture.GetterSetterPathXML))
            {
                MessageBox.Show("Empty path XML", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {          
                if (RadioButton_New.Checked)
                {
                    if (ControllerFurniture.LoadXML())
                    {
                        ControllerFurniture.NewXMLImport();
                    }
                }
                else if (RadioButton_Update.Checked)
                {
                    if (ControllerFurniture.LoadXML())
                    {
                        ControllerFurniture.UpdateXMLImport();
                    }
                }
                else
                {
                    MessageBox.Show("Please select \"New\" or \"Update\" checkbox !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
    }
}

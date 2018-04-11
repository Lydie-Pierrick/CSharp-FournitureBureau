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
using System.Threading;

namespace Mercure
{
    public partial class Dialog_SelectionXML : Form
    {
        private ControllerFurniture ControllerFurniture;
        public static Dialog_SelectionXML DialogSelectionXML;
        private BackgroundWorker BackgroundWorkerData;

        public Dialog_SelectionXML()
        {
            InitializeComponent();
            ControllerFurniture = new ControllerFurniture();
            DialogSelectionXML = this;
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
                    ControllerFurniture.NewXMLImport();
                }
                else if (RadioButton_Update.Checked)
                {
                    ControllerFurniture.UpdateXMLImport();
                }
                else
                {
                    MessageBox.Show("Please select \"New\" or \"Update\" checkbox !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //ProgressBar_ImportXML.Minimum = 1;
                //ProgressBar_ImportXML.Maximum = 100;
                BackgroundWorkerData = new BackgroundWorker();
                BackgroundWorkerData.WorkerReportsProgress = true;
                // This event will be raised on the worker thread when the worker starts
                BackgroundWorkerData.DoWork += BackgroundWorkerData_DoWork;
                // This event will be raised when we call ReportProgress
                BackgroundWorkerData.ProgressChanged += BackgroundWorkerData_ProgressChanged;
                BackgroundWorkerData.RunWorkerCompleted += BackgroundWorkerData_RunWorkerCompleted;
                BackgroundWorkerData.RunWorkerAsync();
            }           
        }

        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dialog_SelectionXML_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxStatusImport_TextChanged(object sender, EventArgs e)
        {

        }

        private void BackgroundWorkerData_DoWork(object sender, DoWorkEventArgs e)
        {
            int RatioProgressBar = (int)(100.0 / (float)ControllerFurniture.NumberNodes);
            for (int Index = 0; Index < ControllerFurniture.NumberNodes; Index++)
            {
                // Report progress bar to change the value
                BackgroundWorkerData.ReportProgress((Index + 1) * RatioProgressBar);
                Thread.Sleep(400);

                // Write every article into BD
                ControllerFurniture.WriteEachArticleDB(Index);
            }
        }

        private void BackgroundWorkerData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar_ImportXML.Value = e.ProgressPercentage;
        }

        private void BackgroundWorkerData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Errors in importation XML !");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Importation XML canceled !");
            }
            else
            {
                // Reset the progress bar
                ProgressBar_ImportXML.Value = 0;
                if (MessageBox.Show("Importation XML completed !") == DialogResult.OK)
                {
                    Close();
                }

                    ControllerFurniture.RefreshListView();
            }        
        }
    }
}

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

namespace Mercure
{
    public partial class Dialog_SelectionXML : Form
    {
        // 1 = New integration
        // 2 = Update
        public static int ChoiceMode = -1;

        public static string PathXML;

        private List<Article> ListArticles;

        public Dialog_SelectionXML()
        {
            InitializeComponent();
            ListArticles = new List<Article>();
        }

        private void Btn_BrowseXML_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader StreamReader = new System.IO.StreamReader(OpenFileDialog.FileName);
                // faire qqch
                StreamReader.Close();
            }

            PathXML = TxtBox_PathXML.Text = OpenFileDialog.FileName;
        }

        private void RadioButton_New_CheckedChanged(object sender, EventArgs e)
        {
            ChoiceMode = 1;
        }

        private void RadioButton_Update_CheckedChanged(object sender, EventArgs e)
        {
            ChoiceMode = 2;
        }

        private void Btn_ImportXML_Click(object sender, EventArgs e)
        {
            XmlDocument XMLDoc = new XmlDocument();

            try
            {
                XMLDoc.Load(PathXML);

            }
            catch (System.IO.FileNotFoundException)
            {

            }

            // Read XML
            XmlNode NodeRoot = XMLDoc.SelectSingleNode("materiels");

            XmlNodeList NodeListRoot = NodeRoot.ChildNodes;

            foreach (XmlNode Node in NodeListRoot)
            {
                Article Article = new Article();

                XmlElement XMLElement = (XmlElement)Node;

                XmlNodeList NodeList = XMLElement.ChildNodes;

                Article.GetSetDescription = NodeList.Item(0).InnerText;
                Article.GetSetReference = NodeList.Item(1).InnerText;
                Article.GetSetBrand = NodeList.Item(2).InnerText;
                Article.GetSetFamilly = NodeList.Item(3).InnerText;
                Article.GetSetSubFamilly = NodeList.Item(4).InnerText;
                Article.GetSetPriceHT = Convert.ToDouble(NodeList.Item(5).InnerText);

                ListArticles.Add(Article);
            }

            NewOrUpdateDB();
        }

        private void NewOrUpdateDB()
        {

        }
    }
}

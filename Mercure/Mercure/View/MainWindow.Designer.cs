namespace Mercure
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Menu_Container = new System.Windows.Forms.MenuStrip();
            this.Menu_Choice1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAnArticleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subFamilyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusSQL_Container = new System.Windows.Forms.StatusStrip();
            MainWindow.StatusSQL_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.addAnArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyThisAritcleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteThisArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ListViewArticles = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_Container.SuspendLayout();
            this.StatusSQL_Container.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu_Container
            // 
            this.Menu_Container.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Choice1,
            this.managementToolStripMenuItem});
            this.Menu_Container.Location = new System.Drawing.Point(0, 0);
            this.Menu_Container.Name = "Menu_Container";
            this.Menu_Container.Size = new System.Drawing.Size(1025, 24);
            this.Menu_Container.TabIndex = 0;
            this.Menu_Container.Text = "menuStrip";
            // 
            // Menu_Choice1
            // 
            this.Menu_Choice1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openXMLToolStripMenuItem,
            this.addAnArticleToolStripMenuItem1});
            this.Menu_Choice1.Name = "Menu_Choice1";
            this.Menu_Choice1.Size = new System.Drawing.Size(37, 20);
            this.Menu_Choice1.Text = "File";
            // 
            // openXMLToolStripMenuItem
            // 
            this.openXMLToolStripMenuItem.Name = "openXMLToolStripMenuItem";
            this.openXMLToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.openXMLToolStripMenuItem.Text = "Open XML";
            this.openXMLToolStripMenuItem.Click += new System.EventHandler(this.openXMLToolStripMenuItem_Click);
            // 
            // addAnArticleToolStripMenuItem1
            // 
            this.addAnArticleToolStripMenuItem1.Name = "addAnArticleToolStripMenuItem1";
            this.addAnArticleToolStripMenuItem1.Size = new System.Drawing.Size(149, 22);
            this.addAnArticleToolStripMenuItem1.Text = "Add an Article";
            this.addAnArticleToolStripMenuItem1.Click += new System.EventHandler(this.addAnArticleToolStripMenuItem1_Click);
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brandToolStripMenuItem,
            this.familyToolStripMenuItem,
            this.subFamilyToolStripMenuItem});
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.managementToolStripMenuItem.Text = "Management";
            // 
            // brandToolStripMenuItem
            // 
            this.brandToolStripMenuItem.Name = "brandToolStripMenuItem";
            this.brandToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.brandToolStripMenuItem.Text = "Brand";
            this.brandToolStripMenuItem.Click += new System.EventHandler(this.brandToolStripMenuItem_Click);
            // 
            // familyToolStripMenuItem
            // 
            this.familyToolStripMenuItem.Name = "familyToolStripMenuItem";
            this.familyToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.familyToolStripMenuItem.Text = "Family";
            this.familyToolStripMenuItem.Click += new System.EventHandler(this.familyToolStripMenuItem_Click);
            // 
            // subFamilyToolStripMenuItem
            // 
            this.subFamilyToolStripMenuItem.Name = "subFamilyToolStripMenuItem";
            this.subFamilyToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.subFamilyToolStripMenuItem.Text = "Sub Family";
            this.subFamilyToolStripMenuItem.Click += new System.EventHandler(this.subFamilyToolStripMenuItem_Click);
            // 
            // StatusSQL_Container
            // 
            this.StatusSQL_Container.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MainWindow.StatusSQL_Label});
            this.StatusSQL_Container.Location = new System.Drawing.Point(0, 380);
            this.StatusSQL_Container.Name = "StatusSQL_Container";
            this.StatusSQL_Container.Size = new System.Drawing.Size(808, 22);
            this.StatusSQL_Container.TabIndex = 1;
            this.StatusSQL_Container.Text = "statusStrip1";
            // 
            // StatusSQL_Label
            // 
            MainWindow.StatusSQL_Label.Name = "StatusSQL_Label";
            MainWindow.StatusSQL_Label.Size = new System.Drawing.Size(39, 17);
            MainWindow.StatusSQL_Label.Text = "Status";
            // 
            // addAnArticleToolStripMenuItem
            // 
            this.addAnArticleToolStripMenuItem.Name = "addAnArticleToolStripMenuItem";
            this.addAnArticleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.addAnArticleToolStripMenuItem.Text = "Add an article";
            this.addAnArticleToolStripMenuItem.Click += new System.EventHandler(this.addAnArticleToolStripMenuItem_Click_1);
            // 
            // modifyThisAritcleToolStripMenuItem
            // 
            this.modifyThisAritcleToolStripMenuItem.Name = "modifyThisAritcleToolStripMenuItem";
            this.modifyThisAritcleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.modifyThisAritcleToolStripMenuItem.Text = "Modify this aritcle";
            this.modifyThisAritcleToolStripMenuItem.Click += new System.EventHandler(this.modifyThisAritcleToolStripMenuItem_Click);
            // 
            // deleteThisArticleToolStripMenuItem
            // 
            this.deleteThisArticleToolStripMenuItem.Name = "deleteThisArticleToolStripMenuItem";
            this.deleteThisArticleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.deleteThisArticleToolStripMenuItem.Text = "Delete this article";
            this.deleteThisArticleToolStripMenuItem.Click += new System.EventHandler(this.deleteThisArticleToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ListViewArticles, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 436);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // ListViewArticles
            // 
            this.ListViewArticles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewArticles.FullRowSelect = true;
            this.ListViewArticles.GridLines = true;
            this.ListViewArticles.LabelWrap = false;
            this.ListViewArticles.Location = new System.Drawing.Point(3, 3);
            this.ListViewArticles.Name = "ListViewArticles";
            this.ListViewArticles.Size = new System.Drawing.Size(995, 430);
            this.ListViewArticles.TabIndex = 6;
            this.ListViewArticles.UseCompatibleStateImageBehavior = false;
            this.ListViewArticles.View = System.Windows.Forms.View.Details;
            this.ListViewArticles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewArticles_ColumnClick);
            this.ListViewArticles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewArticles_MouseClick);
            this.ListViewArticles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewArticles_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAnArticleToolStripMenuItem,
            this.modifyThisAritcleToolStripMenuItem,
            this.deleteThisArticleToolStripMenuItem});
            this.contextMenuStrip1.Name = "ContextMenuStrip";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 70);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 497);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.StatusSQL_Container);
            this.Controls.Add(this.Menu_Container);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Window";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.Menu_Container.ResumeLayout(false);
            this.Menu_Container.PerformLayout();
            this.StatusSQL_Container.ResumeLayout(false);
            this.StatusSQL_Container.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu_Container;
        private System.Windows.Forms.ToolStripMenuItem Menu_Choice1;
        private System.Windows.Forms.StatusStrip StatusSQL_Container;
        public static System.Windows.Forms.ToolStripStatusLabel StatusSQL_Label;
        private System.Windows.Forms.ToolStripMenuItem openXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAnArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyThisAritcleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteThisArticleToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ListView ListViewArticles;
        private System.Windows.Forms.ToolStripMenuItem addAnArticleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subFamilyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
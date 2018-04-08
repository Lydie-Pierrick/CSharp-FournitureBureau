﻿namespace Mercure
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
            this.StatusSQL_Container = new System.Windows.Forms.StatusStrip();
            this.StatusSQL_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.ListViewArticles = new System.Windows.Forms.ListView();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAnArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyThisAritcleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteThisArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Container.SuspendLayout();
            this.StatusSQL_Container.SuspendLayout();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu_Container
            // 
            this.Menu_Container.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Choice1});
            this.Menu_Container.Location = new System.Drawing.Point(0, 0);
            this.Menu_Container.Name = "Menu_Container";
            this.Menu_Container.Size = new System.Drawing.Size(808, 24);
            this.Menu_Container.TabIndex = 0;
            this.Menu_Container.Text = "menuStrip";
            // 
            // Menu_Choice1
            // 
            this.Menu_Choice1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openXMLToolStripMenuItem});
            this.Menu_Choice1.Name = "Menu_Choice1";
            this.Menu_Choice1.Size = new System.Drawing.Size(37, 20);
            this.Menu_Choice1.Text = "File";
            // 
            // openXMLToolStripMenuItem
            // 
            this.openXMLToolStripMenuItem.Name = "openXMLToolStripMenuItem";
            this.openXMLToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.openXMLToolStripMenuItem.Text = "Open XML";
            this.openXMLToolStripMenuItem.Click += new System.EventHandler(this.openXMLToolStripMenuItem_Click);
            // 
            // StatusSQL_Container
            // 
            this.StatusSQL_Container.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusSQL_Label});
            this.StatusSQL_Container.Location = new System.Drawing.Point(0, 380);
            this.StatusSQL_Container.Name = "StatusSQL_Container";
            this.StatusSQL_Container.Size = new System.Drawing.Size(808, 22);
            this.StatusSQL_Container.TabIndex = 1;
            this.StatusSQL_Container.Text = "statusStrip1";
            // 
            // StatusSQL_Label
            // 
            this.StatusSQL_Label.Name = "StatusSQL_Label";
            this.StatusSQL_Label.Size = new System.Drawing.Size(39, 17);
            this.StatusSQL_Label.Text = "Status";
            // 
            // ListViewArticles
            // 
            this.ListViewArticles.GridLines = true;
            this.ListViewArticles.LabelWrap = false;
            this.ListViewArticles.Location = new System.Drawing.Point(12, 27);
            this.ListViewArticles.Name = "ListViewArticles";
            this.ListViewArticles.Size = new System.Drawing.Size(784, 350);
            this.ListViewArticles.TabIndex = 2;
            this.ListViewArticles.UseCompatibleStateImageBehavior = false;
            this.ListViewArticles.View = System.Windows.Forms.View.Details;
            this.ListViewArticles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewArticles_ColumnClick);
            this.ListViewArticles.DoubleClick += new System.EventHandler(this.ListViewArticles_DoubleClick);
            this.ListViewArticles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewArticles_MouseClick);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAnArticleToolStripMenuItem,
            this.modifyThisAritcleToolStripMenuItem,
            this.deleteThisArticleToolStripMenuItem});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(170, 92);
            // 
            // addAnArticleToolStripMenuItem
            // 
            this.addAnArticleToolStripMenuItem.Name = "addAnArticleToolStripMenuItem";
            this.addAnArticleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.addAnArticleToolStripMenuItem.Text = "Add an article";
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
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 402);
            this.Controls.Add(this.ListViewArticles);
            this.Controls.Add(this.StatusSQL_Container);
            this.Controls.Add(this.Menu_Container);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.Text = "Main Window";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.Menu_Container.ResumeLayout(false);
            this.Menu_Container.PerformLayout();
            this.StatusSQL_Container.ResumeLayout(false);
            this.StatusSQL_Container.PerformLayout();
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu_Container;
        private System.Windows.Forms.ToolStripMenuItem Menu_Choice1;
        private System.Windows.Forms.StatusStrip StatusSQL_Container;
        private System.Windows.Forms.ToolStripStatusLabel StatusSQL_Label;
        private System.Windows.Forms.ToolStripMenuItem openXMLToolStripMenuItem;
        public System.Windows.Forms.ListView ListViewArticles;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addAnArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyThisAritcleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteThisArticleToolStripMenuItem;

    }
}
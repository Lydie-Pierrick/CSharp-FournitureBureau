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
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
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
            this.Menu_Container = new System.Windows.Forms.MenuStrip();
            this.Menu_Choice1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusSQL_Container = new System.Windows.Forms.StatusStrip();
            this.StatusSQL_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.ListViewArticles = new System.Windows.Forms.ListView();
            this.RefArticle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SubFamily = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Brand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Menu_Container.SuspendLayout();
            this.StatusSQL_Container.SuspendLayout();
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
            this.StatusSQL_Container.Location = new System.Drawing.Point(0, 414);
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
            this.ListViewArticles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RefArticle,
            this.Description,
            this.SubFamily,
            this.Brand,
            this.Price,
            this.Quantity});
            this.ListViewArticles.GridLines = true;
            this.ListViewArticles.LabelWrap = false;
            this.ListViewArticles.Location = new System.Drawing.Point(12, 29);
            this.ListViewArticles.Name = "ListViewArticles";
            this.ListViewArticles.Size = new System.Drawing.Size(784, 379);
            this.ListViewArticles.TabIndex = 2;
            this.ListViewArticles.UseCompatibleStateImageBehavior = false;
            this.ListViewArticles.View = System.Windows.Forms.View.Details;
            this.ListViewArticles.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewArticles_ColumnClick);
            // 
            // RefArticle
            // 
            this.RefArticle.Text = "RefArticle";
            this.RefArticle.Width = 133;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 219;
            // 
            // SubFamily
            // 
            this.SubFamily.DisplayIndex = 3;
            this.SubFamily.Text = "SubFamily";
            this.SubFamily.Width = 111;
            // 
            // Brand
            // 
            this.Brand.DisplayIndex = 2;
            this.Brand.Text = "Brand";
            this.Brand.Width = 128;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 83;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 104;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 436);
            this.Controls.Add(this.ListViewArticles);
            this.Controls.Add(this.StatusSQL_Container);
            this.Controls.Add(this.Menu_Container);
            this.Name = "MainWindow";
            this.Text = "Main Window";
            this.Menu_Container.ResumeLayout(false);
            this.Menu_Container.PerformLayout();
            this.StatusSQL_Container.ResumeLayout(false);
            this.StatusSQL_Container.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu_Container;
        private System.Windows.Forms.ToolStripMenuItem Menu_Choice1;
        private System.Windows.Forms.StatusStrip StatusSQL_Container;
        private System.Windows.Forms.ToolStripStatusLabel StatusSQL_Label;
        private System.Windows.Forms.ToolStripMenuItem openXMLToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader RefArticle;
        private System.Windows.Forms.ColumnHeader Brand;
        private System.Windows.Forms.ColumnHeader SubFamily;
        private System.Windows.Forms.ColumnHeader Price;
        public System.Windows.Forms.ListView ListViewArticles;
        private System.Windows.Forms.ColumnHeader Quantity;

    }
}


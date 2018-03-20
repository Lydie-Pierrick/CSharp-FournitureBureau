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
            this.StatusSQL_Container = new System.Windows.Forms.StatusStrip();
            this.StatusSQL_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.openXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.Menu_Container.Size = new System.Drawing.Size(284, 24);
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
            // StatusSQL_Container
            // 
            this.StatusSQL_Container.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusSQL_Label});
            this.StatusSQL_Container.Location = new System.Drawing.Point(0, 239);
            this.StatusSQL_Container.Name = "StatusSQL_Container";
            this.StatusSQL_Container.Size = new System.Drawing.Size(284, 22);
            this.StatusSQL_Container.TabIndex = 1;
            this.StatusSQL_Container.Text = "statusStrip1";
            // 
            // StatusSQL_Label
            // 
            this.StatusSQL_Label.Name = "StatusSQL_Label";
            this.StatusSQL_Label.Size = new System.Drawing.Size(39, 17);
            this.StatusSQL_Label.Text = "Status";
            // 
            // openXMLToolStripMenuItem
            // 
            this.openXMLToolStripMenuItem.Name = "openXMLToolStripMenuItem";
            this.openXMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openXMLToolStripMenuItem.Text = "Open XML";
            this.openXMLToolStripMenuItem.Click += new System.EventHandler(this.openXMLToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
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

    }
}


namespace Mercure.View
{
    partial class Dialog_Basic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ListViewBasic = new System.Windows.Forms.ListView();
            this.ContextMenuStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.modifyToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.ContextMenuStrip.Name = "contextMenuStrip1";
            this.ContextMenuStrip.Size = new System.Drawing.Size(113, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.modifyToolStripMenuItem.Text = "Modify";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(528, 24);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
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
            this.tableLayoutPanel1.Controls.Add(this.ListViewBasic, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 375);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ListViewBasic
            // 
            this.ListViewBasic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewBasic.Location = new System.Drawing.Point(3, 3);
            this.ListViewBasic.MinimumSize = new System.Drawing.Size(500, 370);
            this.ListViewBasic.Name = "ListViewBasic";
            this.ListViewBasic.Size = new System.Drawing.Size(500, 370);
            this.ListViewBasic.TabIndex = 2;
            this.ListViewBasic.UseCompatibleStateImageBehavior = false;
            this.ListViewBasic.View = System.Windows.Forms.View.Details;
            this.ListViewBasic.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListViewBasic_KeyDown);
            this.ListViewBasic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewBasic_MouseClick);
            this.ListViewBasic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewBasic_MouseDoubleClick);
            // 
            // Dialog_Basic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 410);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(544, 449);
            this.Name = "Dialog_Basic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog_Basic";
            this.ContextMenuStrip.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ListView ListViewBasic;
    }
}
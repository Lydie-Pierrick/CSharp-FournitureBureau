namespace Mercure.View
{
    partial class Dialog_AddEditBrand
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
            this.LabelRefBrand = new System.Windows.Forms.Label();
            this.TextRefBrand = new System.Windows.Forms.Label();
            this.LabelBrandName = new System.Windows.Forms.Label();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelRefBrand
            // 
            this.LabelRefBrand.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelRefBrand.AutoSize = true;
            this.LabelRefBrand.Location = new System.Drawing.Point(58, 35);
            this.LabelRefBrand.Name = "LabelRefBrand";
            this.LabelRefBrand.Size = new System.Drawing.Size(58, 13);
            this.LabelRefBrand.TabIndex = 0;
            this.LabelRefBrand.Text = "Brand Ref.";
            this.LabelRefBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextRefBrand
            // 
            this.TextRefBrand.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TextRefBrand.AutoSize = true;
            this.TextRefBrand.Location = new System.Drawing.Point(177, 35);
            this.TextRefBrand.Name = "TextRefBrand";
            this.TextRefBrand.Size = new System.Drawing.Size(10, 13);
            this.TextRefBrand.TabIndex = 0;
            this.TextRefBrand.Text = "-";
            this.TextRefBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelBrandName
            // 
            this.LabelBrandName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelBrandName.AutoSize = true;
            this.LabelBrandName.Location = new System.Drawing.Point(54, 118);
            this.LabelBrandName.Name = "LabelBrandName";
            this.LabelBrandName.Size = new System.Drawing.Size(66, 13);
            this.LabelBrandName.TabIndex = 2;
            this.LabelBrandName.Text = "Brand Name";
            this.LabelBrandName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBox
            // 
            this.TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox.Location = new System.Drawing.Point(177, 115);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(269, 20);
            this.TextBox.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.93443F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.06557F));
            this.tableLayoutPanel1.Controls.Add(this.LabelRefBrand, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextRefBrand, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelBrandName, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 167);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.Location = new System.Drawing.Point(3, 13);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(218, 25);
            this.BtnOK.TabIndex = 0;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(227, 13);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(219, 25);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(17, 13);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.94936F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.05063F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(455, 257);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.BtnCancel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnOK, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 198);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(449, 51);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // Dialog_AddEditBrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 283);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Dialog_AddEditBrand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog_AddEditBrand";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelRefBrand;
        private System.Windows.Forms.Label TextRefBrand;
        private System.Windows.Forms.Label LabelBrandName;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
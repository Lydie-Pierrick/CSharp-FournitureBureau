namespace Mercure.View
{
    partial class Dialog_AddEditFamily
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
            this.TextRefFamily = new System.Windows.Forms.Label();
            this.LabelFamilyName = new System.Windows.Forms.Label();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancle = new System.Windows.Forms.Button();
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
            this.LabelRefBrand.Location = new System.Drawing.Point(46, 32);
            this.LabelRefBrand.Name = "LabelRefBrand";
            this.LabelRefBrand.Size = new System.Drawing.Size(71, 12);
            this.LabelRefBrand.TabIndex = 0;
            this.LabelRefBrand.Text = "Family Ref.";
            this.LabelRefBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextRefFamily
            // 
            this.TextRefFamily.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TextRefFamily.AutoSize = true;
            this.TextRefFamily.Location = new System.Drawing.Point(166, 32);
            this.TextRefFamily.Name = "TextRefFamily";
            this.TextRefFamily.Size = new System.Drawing.Size(11, 12);
            this.TextRefFamily.TabIndex = 0;
            this.TextRefFamily.Text = "-";
            this.TextRefFamily.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelFamilyName
            // 
            this.LabelFamilyName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelFamilyName.AutoSize = true;
            this.LabelFamilyName.Location = new System.Drawing.Point(46, 109);
            this.LabelFamilyName.Name = "LabelFamilyName";
            this.LabelFamilyName.Size = new System.Drawing.Size(71, 12);
            this.LabelFamilyName.TabIndex = 2;
            this.LabelFamilyName.Text = "Family Name";
            this.LabelFamilyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBox
            // 
            this.TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox.Location = new System.Drawing.Point(166, 105);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(280, 21);
            this.TextBox.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.52561F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.47439F));
            this.tableLayoutPanel1.Controls.Add(this.LabelRefBrand, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextRefFamily, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelFamilyName, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 154);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.Location = new System.Drawing.Point(227, 12);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(219, 23);
            this.BtnOK.TabIndex = 0;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancle
            // 
            this.BtnCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancle.Location = new System.Drawing.Point(3, 12);
            this.BtnCancle.Name = "BtnCancle";
            this.BtnCancle.Size = new System.Drawing.Size(218, 23);
            this.BtnCancle.TabIndex = 1;
            this.BtnCancle.Text = "Cancel";
            this.BtnCancle.UseVisualStyleBackColor = true;
            this.BtnCancle.Click += new System.EventHandler(this.BtnCancle_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(17, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.94936F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.05063F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(455, 237);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.BtnOK, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnCancle, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 183);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(449, 47);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // Dialog_AddEditFamily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Dialog_AddEditFamily";
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
        private System.Windows.Forms.Label TextRefFamily;
        private System.Windows.Forms.Label LabelFamilyName;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
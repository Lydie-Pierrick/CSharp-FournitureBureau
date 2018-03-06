namespace Mercure
{
    partial class Dialog_SelectionXML
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
            this.Btn_ImportXML = new System.Windows.Forms.Button();
            this.ProgressBar_ImportXML = new System.Windows.Forms.ProgressBar();
            this.TxtBox_PathXML = new System.Windows.Forms.TextBox();
            this.Btn_BrowseXML = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Label_Progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_ImportXML
            // 
            this.Btn_ImportXML.Location = new System.Drawing.Point(216, 117);
            this.Btn_ImportXML.Name = "Btn_ImportXML";
            this.Btn_ImportXML.Size = new System.Drawing.Size(75, 23);
            this.Btn_ImportXML.TabIndex = 0;
            this.Btn_ImportXML.Text = "Import";
            this.Btn_ImportXML.UseVisualStyleBackColor = true;
            // 
            // ProgressBar_ImportXML
            // 
            this.ProgressBar_ImportXML.Location = new System.Drawing.Point(98, 226);
            this.ProgressBar_ImportXML.Name = "ProgressBar_ImportXML";
            this.ProgressBar_ImportXML.Size = new System.Drawing.Size(372, 23);
            this.ProgressBar_ImportXML.TabIndex = 1;
            // 
            // TxtBox_PathXML
            // 
            this.TxtBox_PathXML.Location = new System.Drawing.Point(32, 68);
            this.TxtBox_PathXML.Name = "TxtBox_PathXML";
            this.TxtBox_PathXML.Size = new System.Drawing.Size(338, 21);
            this.TxtBox_PathXML.TabIndex = 2;
            // 
            // Btn_BrowseXML
            // 
            this.Btn_BrowseXML.Location = new System.Drawing.Point(383, 68);
            this.Btn_BrowseXML.Name = "Btn_BrowseXML";
            this.Btn_BrowseXML.Size = new System.Drawing.Size(75, 23);
            this.Btn_BrowseXML.TabIndex = 3;
            this.Btn_BrowseXML.Text = "Browse";
            this.Btn_BrowseXML.UseVisualStyleBackColor = true;
            this.Btn_BrowseXML.Click += new System.EventHandler(this.Btn_BrowseXML_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // Label_Progress
            // 
            this.Label_Progress.AutoSize = true;
            this.Label_Progress.Location = new System.Drawing.Point(12, 232);
            this.Label_Progress.Name = "Label_Progress";
            this.Label_Progress.Size = new System.Drawing.Size(77, 12);
            this.Label_Progress.TabIndex = 4;
            this.Label_Progress.Text = "Progress Bar";
            // 
            // Dialog_SelectionXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 261);
            this.Controls.Add(this.Label_Progress);
            this.Controls.Add(this.Btn_BrowseXML);
            this.Controls.Add(this.TxtBox_PathXML);
            this.Controls.Add(this.ProgressBar_ImportXML);
            this.Controls.Add(this.Btn_ImportXML);
            this.Name = "Dialog_SelectionXML";
            this.Text = "Selection of .XML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_ImportXML;
        private System.Windows.Forms.ProgressBar ProgressBar_ImportXML;
        private System.Windows.Forms.TextBox TxtBox_PathXML;
        private System.Windows.Forms.Button Btn_BrowseXML;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Label Label_Progress;
    }
}
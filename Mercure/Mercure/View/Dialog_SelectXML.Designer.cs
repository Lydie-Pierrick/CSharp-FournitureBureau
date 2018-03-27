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
            this.RadioButton_Update = new System.Windows.Forms.RadioButton();
            this.GroupBox_TwoModes = new System.Windows.Forms.GroupBox();
            this.RadioButton_New = new System.Windows.Forms.RadioButton();
            this.GroupBox_TwoModes.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_ImportXML
            // 
            this.Btn_ImportXML.Location = new System.Drawing.Point(192, 176);
            this.Btn_ImportXML.Name = "Btn_ImportXML";
            this.Btn_ImportXML.Size = new System.Drawing.Size(75, 25);
            this.Btn_ImportXML.TabIndex = 0;
            this.Btn_ImportXML.Text = "Import";
            this.Btn_ImportXML.UseVisualStyleBackColor = true;
            this.Btn_ImportXML.Click += new System.EventHandler(this.Btn_ImportXML_Click);
            // 
            // ProgressBar_ImportXML
            // 
            this.ProgressBar_ImportXML.Location = new System.Drawing.Point(98, 245);
            this.ProgressBar_ImportXML.Name = "ProgressBar_ImportXML";
            this.ProgressBar_ImportXML.Size = new System.Drawing.Size(372, 25);
            this.ProgressBar_ImportXML.TabIndex = 1;
            // 
            // TxtBox_PathXML
            // 
            this.TxtBox_PathXML.Location = new System.Drawing.Point(32, 74);
            this.TxtBox_PathXML.Name = "TxtBox_PathXML";
            this.TxtBox_PathXML.Size = new System.Drawing.Size(338, 20);
            this.TxtBox_PathXML.TabIndex = 2;
            // 
            // Btn_BrowseXML
            // 
            this.Btn_BrowseXML.Location = new System.Drawing.Point(383, 74);
            this.Btn_BrowseXML.Name = "Btn_BrowseXML";
            this.Btn_BrowseXML.Size = new System.Drawing.Size(75, 25);
            this.Btn_BrowseXML.TabIndex = 3;
            this.Btn_BrowseXML.Text = "Browse";
            this.Btn_BrowseXML.UseVisualStyleBackColor = true;
            this.Btn_BrowseXML.Click += new System.EventHandler(this.Btn_BrowseXML_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            this.OpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
            // 
            // Label_Progress
            // 
            this.Label_Progress.AutoSize = true;
            this.Label_Progress.Location = new System.Drawing.Point(12, 251);
            this.Label_Progress.Name = "Label_Progress";
            this.Label_Progress.Size = new System.Drawing.Size(67, 13);
            this.Label_Progress.TabIndex = 4;
            this.Label_Progress.Text = "Progress Bar";
            // 
            // RadioButton_Update
            // 
            this.RadioButton_Update.AutoSize = true;
            this.RadioButton_Update.Location = new System.Drawing.Point(97, 19);
            this.RadioButton_Update.Name = "RadioButton_Update";
            this.RadioButton_Update.Size = new System.Drawing.Size(60, 17);
            this.RadioButton_Update.TabIndex = 5;
            this.RadioButton_Update.TabStop = true;
            this.RadioButton_Update.Text = "Update";
            this.RadioButton_Update.UseVisualStyleBackColor = true;
            // 
            // GroupBox_TwoModes
            // 
            this.GroupBox_TwoModes.Controls.Add(this.RadioButton_New);
            this.GroupBox_TwoModes.Controls.Add(this.RadioButton_Update);
            this.GroupBox_TwoModes.Location = new System.Drawing.Point(129, 116);
            this.GroupBox_TwoModes.Name = "GroupBox_TwoModes";
            this.GroupBox_TwoModes.Size = new System.Drawing.Size(186, 45);
            this.GroupBox_TwoModes.TabIndex = 6;
            this.GroupBox_TwoModes.TabStop = false;
            // 
            // RadioButton_New
            // 
            this.RadioButton_New.AutoSize = true;
            this.RadioButton_New.Location = new System.Drawing.Point(6, 19);
            this.RadioButton_New.Name = "RadioButton_New";
            this.RadioButton_New.Size = new System.Drawing.Size(47, 17);
            this.RadioButton_New.TabIndex = 6;
            this.RadioButton_New.TabStop = true;
            this.RadioButton_New.Text = "New";
            this.RadioButton_New.UseVisualStyleBackColor = true;
            // 
            // Dialog_SelectionXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 283);
            this.Controls.Add(this.GroupBox_TwoModes);
            this.Controls.Add(this.Label_Progress);
            this.Controls.Add(this.Btn_BrowseXML);
            this.Controls.Add(this.TxtBox_PathXML);
            this.Controls.Add(this.ProgressBar_ImportXML);
            this.Controls.Add(this.Btn_ImportXML);
            this.Name = "Dialog_SelectionXML";
            this.Text = "Selection of .XML";
            this.GroupBox_TwoModes.ResumeLayout(false);
            this.GroupBox_TwoModes.PerformLayout();
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
        private System.Windows.Forms.RadioButton RadioButton_Update;
        private System.Windows.Forms.GroupBox GroupBox_TwoModes;
        private System.Windows.Forms.RadioButton RadioButton_New;
    }
}
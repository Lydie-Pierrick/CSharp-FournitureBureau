namespace Mercure.View
{
    partial class Dialog_Brand
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
            this.ListViewBrands = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ListViewBrands
            // 
            this.ListViewBrands.Location = new System.Drawing.Point(12, 12);
            this.ListViewBrands.Name = "ListViewBrands";
            this.ListViewBrands.Size = new System.Drawing.Size(460, 337);
            this.ListViewBrands.TabIndex = 0;
            this.ListViewBrands.UseCompatibleStateImageBehavior = false;
            this.ListViewBrands.View = System.Windows.Forms.View.Details;
            // 
            // Dialog_Brand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.ListViewBrands);
            this.Name = "Dialog_Brand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog_Brand";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView ListViewBrands;

    }
}
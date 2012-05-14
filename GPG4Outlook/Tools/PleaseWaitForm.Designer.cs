namespace GPG4OutlookLib.Tools
{
    partial class PleaseWaitForm
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
            this.pleaseWaitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pleaseWaitLabel
            // 
            this.pleaseWaitLabel.AutoSize = true;
            this.pleaseWaitLabel.Location = new System.Drawing.Point(43, 36);
            this.pleaseWaitLabel.Name = "pleaseWaitLabel";
            this.pleaseWaitLabel.Size = new System.Drawing.Size(227, 13);
            this.pleaseWaitLabel.TabIndex = 0;
            this.pleaseWaitLabel.Text = "Please wait and enter the password if promted.";
            // 
            // PleaseWaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 86);
            this.ControlBox = false;
            this.Controls.Add(this.pleaseWaitLabel);
            this.Name = "PleaseWaitForm";
            this.Text = "Please wait";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pleaseWaitLabel;
    }
}
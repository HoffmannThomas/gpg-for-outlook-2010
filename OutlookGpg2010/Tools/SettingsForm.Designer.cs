namespace OutlookGpg2010.Tools
{
    partial class SettingsForm
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
            this.AlwaysSignBox = new System.Windows.Forms.CheckBox();
            this.AlwaysEncryptBox = new System.Windows.Forms.CheckBox();
            this.AlwaysDecryptBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AlwaysSignBox
            // 
            this.AlwaysSignBox.AutoSize = true;
            this.AlwaysSignBox.Location = new System.Drawing.Point(15, 34);
            this.AlwaysSignBox.Name = "AlwaysSignBox";
            this.AlwaysSignBox.Size = new System.Drawing.Size(83, 17);
            this.AlwaysSignBox.TabIndex = 0;
            this.AlwaysSignBox.Text = "Always Sign";
            this.AlwaysSignBox.UseVisualStyleBackColor = true;
            this.AlwaysSignBox.CheckedChanged += new System.EventHandler(this.AlwaysSignBox_CheckedChanged);
            // 
            // AlwaysEncryptBox
            // 
            this.AlwaysEncryptBox.AutoSize = true;
            this.AlwaysEncryptBox.Location = new System.Drawing.Point(15, 70);
            this.AlwaysEncryptBox.Name = "AlwaysEncryptBox";
            this.AlwaysEncryptBox.Size = new System.Drawing.Size(98, 17);
            this.AlwaysEncryptBox.TabIndex = 1;
            this.AlwaysEncryptBox.Text = "Always Encrypt";
            this.AlwaysEncryptBox.UseVisualStyleBackColor = true;
            this.AlwaysEncryptBox.CheckedChanged += new System.EventHandler(this.AlwaysEncryptBox_CheckedChanged);
            // 
            // AlwaysDecryptBox
            // 
            this.AlwaysDecryptBox.AutoSize = true;
            this.AlwaysDecryptBox.Location = new System.Drawing.Point(15, 110);
            this.AlwaysDecryptBox.Name = "AlwaysDecryptBox";
            this.AlwaysDecryptBox.Size = new System.Drawing.Size(99, 17);
            this.AlwaysDecryptBox.TabIndex = 2;
            this.AlwaysDecryptBox.Text = "Always Decrypt";
            this.AlwaysDecryptBox.UseVisualStyleBackColor = true;
            this.AlwaysDecryptBox.CheckedChanged += new System.EventHandler(this.AlwaysDecryptBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Check if you want to sign every send mail per default:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Check if you want to encrypt every send mail per default:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Check if you want to decrypt every recieved mail per default:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(53, 157);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save settings";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(161, 157);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(322, 194);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AlwaysDecryptBox);
            this.Controls.Add(this.AlwaysEncryptBox);
            this.Controls.Add(this.AlwaysSignBox);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AlwaysSignBox;
        private System.Windows.Forms.CheckBox AlwaysEncryptBox;
        private System.Windows.Forms.CheckBox AlwaysDecryptBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
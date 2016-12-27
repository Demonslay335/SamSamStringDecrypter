namespace SamSamStringDecrypter
{
    partial class SetPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetPasswordForm));
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.SaltLabel = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.SaltTextbox = new System.Windows.Forms.TextBox();
            this.SetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 12);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(78, 13);
            this.PasswordLabel.TabIndex = 0;
            this.PasswordLabel.Text = "Shared Secret:";
            // 
            // SaltLabel
            // 
            this.SaltLabel.AutoSize = true;
            this.SaltLabel.Location = new System.Drawing.Point(62, 38);
            this.SaltLabel.Name = "SaltLabel";
            this.SaltLabel.Size = new System.Drawing.Size(28, 13);
            this.SaltLabel.TabIndex = 1;
            this.SaltLabel.Text = "Salt:";
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(96, 12);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(210, 20);
            this.PasswordTextbox.TabIndex = 2;
            // 
            // SaltTextbox
            // 
            this.SaltTextbox.Location = new System.Drawing.Point(96, 35);
            this.SaltTextbox.Name = "SaltTextbox";
            this.SaltTextbox.Size = new System.Drawing.Size(210, 20);
            this.SaltTextbox.TabIndex = 3;
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(120, 64);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(75, 23);
            this.SetButton.TabIndex = 4;
            this.SetButton.Text = "Set";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // SetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 99);
            this.Controls.Add(this.SetButton);
            this.Controls.Add(this.SaltTextbox);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.SaltLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetPasswordForm";
            this.Text = "Set Password";
            this.Load += new System.EventHandler(this.SetPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label SaltLabel;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox SaltTextbox;
        private System.Windows.Forms.Button SetButton;
    }
}
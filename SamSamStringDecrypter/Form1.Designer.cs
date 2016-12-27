namespace SamSamStringDecrypter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.EncryptedStringsTextbox = new System.Windows.Forms.RichTextBox();
            this.DecryptedStringsTextbox = new System.Windows.Forms.RichTextBox();
            this.EncryptedStringsLabel = new System.Windows.Forms.Label();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPasswordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.EncryptedStringsTextbox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DecryptedStringsTextbox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.EncryptedStringsLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DecryptButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(463, 323);
            this.tableLayoutPanel1.TabIndex = 7;
            this.tableLayoutPanel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.tableLayoutPanel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_DragEnter);
            // 
            // EncryptedStringsTextbox
            // 
            this.EncryptedStringsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EncryptedStringsTextbox.Location = new System.Drawing.Point(3, 33);
            this.EncryptedStringsTextbox.Name = "EncryptedStringsTextbox";
            this.EncryptedStringsTextbox.Size = new System.Drawing.Size(457, 115);
            this.EncryptedStringsTextbox.TabIndex = 0;
            this.EncryptedStringsTextbox.Text = "";
            // 
            // DecryptedStringsTextbox
            // 
            this.DecryptedStringsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DecryptedStringsTextbox.Location = new System.Drawing.Point(3, 184);
            this.DecryptedStringsTextbox.Name = "DecryptedStringsTextbox";
            this.DecryptedStringsTextbox.Size = new System.Drawing.Size(457, 115);
            this.DecryptedStringsTextbox.TabIndex = 1;
            this.DecryptedStringsTextbox.Text = "";
            // 
            // EncryptedStringsLabel
            // 
            this.EncryptedStringsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EncryptedStringsLabel.AutoSize = true;
            this.EncryptedStringsLabel.Location = new System.Drawing.Point(3, 8);
            this.EncryptedStringsLabel.Name = "EncryptedStringsLabel";
            this.EncryptedStringsLabel.Size = new System.Drawing.Size(152, 13);
            this.EncryptedStringsLabel.TabIndex = 2;
            this.EncryptedStringsLabel.Text = "Encrypted strings, one per line.";
            // 
            // DecryptButton
            // 
            this.DecryptButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DecryptButton.Location = new System.Drawing.Point(175, 154);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(113, 23);
            this.DecryptButton.TabIndex = 3;
            this.DecryptButton.Text = "Decrypt Strings";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPasswordToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(463, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setPasswordToolStripMenuItem
            // 
            this.setPasswordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setPasswordToolStripMenuItem1,
            this.loadBinaryToolStripMenuItem});
            this.setPasswordToolStripMenuItem.Name = "setPasswordToolStripMenuItem";
            this.setPasswordToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.setPasswordToolStripMenuItem.Text = "File";
            // 
            // setPasswordToolStripMenuItem1
            // 
            this.setPasswordToolStripMenuItem1.Name = "setPasswordToolStripMenuItem1";
            this.setPasswordToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.setPasswordToolStripMenuItem1.Text = "Set Password";
            this.setPasswordToolStripMenuItem1.Click += new System.EventHandler(this.setPasswordToolStripMenuItem1_Click);
            // 
            // loadBinaryToolStripMenuItem
            // 
            this.loadBinaryToolStripMenuItem.Name = "loadBinaryToolStripMenuItem";
            this.loadBinaryToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.loadBinaryToolStripMenuItem.Text = "Load Binary";
            this.loadBinaryToolStripMenuItem.Click += new System.EventHandler(this.loadBinaryToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(463, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(26, 17);
            this.StatusLabel.Text = "Idle";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 347);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SamSamStringDecrypter";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.File_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.File_DragEnter);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox EncryptedStringsTextbox;
        private System.Windows.Forms.RichTextBox DecryptedStringsTextbox;
        private System.Windows.Forms.Label EncryptedStringsLabel;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPasswordToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripMenuItem loadBinaryToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}


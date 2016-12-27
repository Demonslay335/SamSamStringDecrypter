using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamSamStringDecrypter
{
    public partial class SetPasswordForm : Form
    {
        // Flag that dialog was closed by the button
        public bool closedByButton = false;

        // Constructor
        public SetPasswordForm()
        {
            // Setup form
            InitializeComponent();
        }

        // Form loaded event
        private void SetPasswordForm_Load(object sender, EventArgs e)
        {
            // Set fields to the decrypter's values
            PasswordTextbox.Text = Decrypter.SharedSecret;
            SaltTextbox.Text = Decrypter.Salt;
        }

        // Set button clicked
        private void SetButton_Click(object sender, EventArgs e)
        {
            // Set the decrypter values
            Decrypter.SharedSecret = PasswordTextbox.Text;
            Decrypter.Salt = SaltTextbox.Text;

            // Set closed flag
            closedByButton = true;

            // Close dialog
            Close();
        }
    }
}

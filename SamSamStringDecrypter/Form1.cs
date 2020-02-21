using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamSamStringDecrypter
{
    public partial class Form1 : Form
    {

        // Payload structure
        public struct Payload
        {
            // Encrypted strings
            public List<string> Strings;

            // Shared secret and salt for decryption
            public string SharedSecret;
            public string Salt;
        };

        // Dialog boxes
        private AboutBox aboutBox = new AboutBox();
        private SetPasswordForm setPasswordForm = new SetPasswordForm();

        // Background workers
        static BackgroundWorker DecryptBackgroundWorker = new BackgroundWorker();
        static BackgroundWorker ExtractBackgroundWorker = new BackgroundWorker();

        // Constructor
        public Form1()
        {
            // Initialize form
            InitializeComponent();

            // Setup drag-and-drop
            this.AllowDrop = true;
            this.DragEnter += File_DragEnter;
            this.DragDrop += File_DragDrop;
            EncryptedStringsTextbox.AllowDrop = true;
            EncryptedStringsTextbox.DragEnter += File_DragEnter;
            EncryptedStringsTextbox.DragDrop += File_DragDrop;

            // Setup decryption worker
            DecryptBackgroundWorker.DoWork += DecryptStrings;
            DecryptBackgroundWorker.RunWorkerCompleted += DecryptStringsCompleted;

            // Setup extraction worker
            ExtractBackgroundWorker.DoWork += ExtractEncryptedStrings;
            ExtractBackgroundWorker.RunWorkerCompleted += ExtractEncryptedStringsCompleted;
        }

        // Accept drag drop event
        private void File_DragDrop(object sender, DragEventArgs e)
        {
            // Get first file dropped
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string file = files.First();

            // Start extracting strings from the binary
            StartExtractEncryptedStrings(file);
        }

        // Accept drag enter event
        private void File_DragEnter(object sender, DragEventArgs e)
        {
            // Check for data being present
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Set drag effect
                e.Effect = DragDropEffects.Copy;
            }
        }

        #region Buttons

        // Decrypt button
        private void DecryptButton_Click(object sender, EventArgs e)
        {
            // Start decrypting the strings
            StartDecryptStrings();
        }

        // About toolstrip item
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show about dialog
            aboutBox.ShowDialog();
        }

        // Set password toolstrip item
        private void setPasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Show password dialog
            setPasswordForm.ShowDialog();
        }

        // Load binary toolstrip item
        private void loadBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open a file dialog
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Start extracting strings from the file
                StartExtractEncryptedStrings(openFileDialog.FileName);
            }
        }

        #endregion
        
        #region Decrypt strings

        // Start async decryption of strings
        private void StartDecryptStrings()
        {
            // Set status label
            StatusLabel.Text = "Decrypting Strings...";

            // Start background worker
            DecryptBackgroundWorker.RunWorkerAsync(EncryptedStringsTextbox.Lines);
        }

        // Decryption of strings completed
        private void DecryptStringsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Check for error
            if (e.Error != null)
            {
                // Display error
                DecryptedStringsTextbox.Text = e.Error.Message;

                // Set status label
                StatusLabel.Text = "Error";
            }
            // Check for result
            else if (e.Result != null)
            {
                // Display the strings, joined by new lines
                DecryptedStringsTextbox.Text = string.Join(Environment.NewLine, (string[]) e.Result);

                // Set status label
                StatusLabel.Text = "Decrypted";
            }
        }

        // Decryption of strings
        private void DecryptStrings(object sender, DoWorkEventArgs args)
        {
            // Get strings from the argument
            string[] EncryptedStrings = (string[]) args.Argument;

            // List of decrypted strings
            List<string> DecryptedStrings = new List<string>();

            // Iterate the encrypted strings provided
            foreach (string EncryptedString in EncryptedStrings)
            {
                try
                {
                    // Check for an actual string
                    if (EncryptedString != null && EncryptedString.Length > 0)
                    {
                        // Check for unicode string
                        if (Regex.IsMatch(EncryptedString, @"^(([A-F0-9]{2})([0]{2}))*$"))
                        {
                            // Decode string and add to the list
                            DecryptedStrings.Add(Decrypter.DecodeStringUnicode(EncryptedString));
                        }
                        else
                        {
                            // Decrypt string and add to the list
                            DecryptedStrings.Add(Decrypter.DecryptStringAES(EncryptedString));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Display error
                    DecryptedStrings.Add("Error decrypting string: " + ex.Message);
                }
            }

            // Set the decrypted strings as the result
            args.Result = DecryptedStrings.ToArray();
        }

        #endregion

        #region Extraction from binary

        // Start async extraction of strings
        private void StartExtractEncryptedStrings(string filename)
        {
            // Set status label
            StatusLabel.Text = "Extracting Strings...";

            // Start background worker
            ExtractBackgroundWorker.RunWorkerAsync(Path.GetFullPath(filename));
        }

        // Extraction of strings completed
        private void ExtractEncryptedStringsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Check for error
            if (e.Error != null)
            {
                // Display error
                EncryptedStringsTextbox.Text = e.Error.Message;

                // Set status label
                StatusLabel.Text = "Error";
            }
            // Check for result
            else if (e.Result != null)
            {
                // Get payload from result
                Payload payload = (Payload) e.Result;
                
                // Check for encrypted strings
                if (payload.Strings != null)
                {
                    // Display the encrypted strings, joined by new lines
                    EncryptedStringsTextbox.Text = string.Join(Environment.NewLine, payload.Strings.ToArray());
                }

                // Set decrypter fields
                Decrypter.SharedSecret = payload.SharedSecret;
                Decrypter.Salt = payload.Salt;

                // Check for extracted strings
                if (EncryptedStringsTextbox.Text.Length > 0)
                {
                    // Set status label
                    StatusLabel.Text = "Extraction complete";

                    // Start decrypting the strings
                    StartDecryptStrings();
                }
                else
                {
                    // Set status label
                    StatusLabel.Text = "No strings found in binary";
                }
            }
        }

        // Extraction of strings
        private void ExtractEncryptedStrings(object sender, DoWorkEventArgs args)
        {
            // Get assembly name from arguments
            string assemblyName = (string) args.Argument;

            // Build new payload object
            Payload payload = new Payload();

            // Setup decompiler
            DecompilerSettings settings = new DecompilerSettings();
            settings.FullyQualifyAmbiguousTypeNames = true;
            var resolver = new DefaultAssemblyResolver();
            resolver.AddSearchDirectory(Environment.CurrentDirectory);

            var parameters = new ReaderParameters
            {
                AssemblyResolver = resolver,
            };

            AssemblyDefinition assembly1 = AssemblyDefinition.ReadAssembly(assemblyName);

            // Add assembly to the decompiler
            AstBuilder decompiler = new AstBuilder(new DecompilerContext(assembly1.MainModule) { Settings = settings });
            decompiler.AddAssembly(assembly1);

            // Generate the code
            StringWriter output = new StringWriter();
            decompiler.GenerateCode(new PlainTextOutput(output));

            // Get the code from the decompiler into a string
            byte[] byteArray = Encoding.ASCII.GetBytes(output.ToString());
            TextReader codeReader = new StreamReader(new MemoryStream(byteArray));
            string code = codeReader.ReadToEnd();

            // Build regex to extract strings
            List<string> SharedSecretPatterns = new List<string>()
            {
                @"private static string msaltpassss = \""(?<SharedSecret>.+)\"";",
                @"private static string e1 = \""(?<SharedSecret>.+)\"";",
                @"private static string mySalt = \""(?<SharedSecret>.+)\"";"
            };
            List<string> SaltPatterns = new List<string>()
            {
                @"private static byte\[\] _salt = Encoding.ASCII.GetBytes\(\""(?<Salt>.+)\""\);"
            };
            List<string> EncryptedStringsPatterns = new List<string>()
            {
                @"encc.DecryptStringAES\(\""(?<String>.+)\"",",
                @"encc.myff11\(\""(?<String>.+)\"",",
                @"\""(?<String>([A-F0-9]{2})*)\"""
            };

            // Enumerate the shared secret patterns
            foreach(string SharedSecretPattern in SharedSecretPatterns)
            {
                // Match regex
                Match SharedSecretMatch = Regex.Match(code, SharedSecretPattern);

                // Check for success
                if (SharedSecretMatch.Success)
                {
                    // Extract the value
                    payload.SharedSecret = SharedSecretMatch.Groups["SharedSecret"].Value;
                    break;
                }
            }

            // Enumerate the salt patterns
            foreach(string SaltPattern in SaltPatterns)
            {
                // Match regex
                Match SaltMatch = Regex.Match(code, SaltPattern);

                // Check for success
                if (SaltMatch.Success)
                {
                    // Extract the value
                    payload.Salt = SaltMatch.Groups["Salt"].Value;
                    break;
                }
            }

            // Enumerate encrypted string patterns
            foreach(string EncryptedStringsPattern in EncryptedStringsPatterns)
            {
                // Match regex
                MatchCollection StringsMatch = Regex.Matches(code, EncryptedStringsPattern);

                // Check for success
                if (StringsMatch.Count > 0)
                {
                    // Extract the value
                    payload.Strings = StringsMatch.Cast<Match>().Select(m => m.Groups["String"].Value).ToList();
                    break;
                }
            }

            // Set the payload object as the result
            args.Result = payload;
        }

        #endregion
    }

}

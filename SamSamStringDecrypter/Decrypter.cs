using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SamSamStringDecrypter
{
    static public class Decrypter
    {
        // Decryption key and salt
        static public string SharedSecret = "SALT";
        static public string Salt = "o6806642kbM7c5";

        // Decrypt strings with AES
        public static string DecryptStringAES(string cipherText)
        {
            // Check for empty cipher text
            if (string.IsNullOrEmpty(cipherText))
            {
                throw new ArgumentNullException("cipherText");
            }
            // Check for empty key
            if (string.IsNullOrEmpty(SharedSecret))
            {
                throw new ArgumentNullException("Decrypter.SharedSecret");
            }
            // Check for empty salt
            if(string.IsNullOrEmpty(Salt))
            {
                throw new ArgumentNullException("Decrypter.Salt");
            }

            // Decrypted string result
            string result = null;

            try
            {
                // Setup derived bytes
                Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(SharedSecret, Encoding.ASCII.GetBytes(Salt));

                // Convert from base64
                byte[] buffer = Convert.FromBase64String(cipherText);

                // Memory stream for decryption
                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    // AES decrypter
                    using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
                    {
                        // Set key and IV
                        rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
                        rijndaelManaged.IV = ReadByteArray(memoryStream);

                        // Create decryptor transform
                        ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);

                        // Decryption stream
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
                        {
                            // Stream reader
                            using (StreamReader streamReader = new StreamReader(cryptoStream))
                            {
                                // Read the decrypted string from the stream
                                result = streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch(Exception)
            {
                // Ignore
            }

            // Return decrypted string
            return result;
        }

        // Get byte array from a stream
        private static byte[] ReadByteArray(Stream s)
        {
            byte[] array = new byte[4];
            if (s.Read(array, 0, array.Length) != array.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }
            byte[] array2 = new byte[BitConverter.ToInt32(array, 0)];
            if (s.Read(array2, 0, array2.Length) != array2.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }
            return array2;
        }

        // Decode Unicode string
        public static string DecodeStringUnicode(string encodedString)
        {
            byte[] array = new byte[encodedString.Length / 2];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToByte(encodedString.Substring(i * 2, 2), 16);
            }
            return Encoding.Unicode.GetString(array);
        }
    }
}

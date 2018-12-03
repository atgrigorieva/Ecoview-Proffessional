using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    class EncriptorPribor
    {
        string filename, pathname;
        public EncriptorPribor(string filename1, string pathname1)
        {
            this.filename = filename1;
            this.pathname = pathname1;
            PriborEncriptor();
        }
        public void PriborEncriptor()
        {
            try {

                FileStream fsFileOut = File.Create(@filename + "1");
                // The chryptographic service provider we're going to use
                TripleDESCryptoServiceProvider cryptAlgorithm = new TripleDESCryptoServiceProvider();
                // This object links data streams to cryptographic values
                CryptoStream csEncrypt = new CryptoStream(fsFileOut, cryptAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
                // This stream writer will write the new file
                StreamWriter swEncStream = new StreamWriter(csEncrypt);
                // This stream reader will read the file to encrypt
                string filename1 = filename.Substring(filename.LastIndexOf(@"/") + 1);
                string filename2 = filename.Remove(filename.LastIndexOf(@"/") + 1);
                StreamReader srFile = new StreamReader(filename2 + filename1);

                string currLine = srFile.ReadLine();
                while (currLine != null)
                {
                    // Write to the encryption stream
                    swEncStream.Write(currLine);
                    currLine = srFile.ReadLine();
                }
                // Wrap things up
                srFile.Close();
                swEncStream.Flush();
                swEncStream.Close();

                // Create the key file
                FileStream fsFileKey = File.Create(filename + "1" + ".key");
                BinaryWriter bwFile = new BinaryWriter(fsFileKey);
                bwFile.Write(cryptAlgorithm.Key);
                bwFile.Write(cryptAlgorithm.IV);
                bwFile.Flush();
                bwFile.Close();
                fsFileOut.Close();
                fsFileKey.Close();
                File.Delete(@filename);
                File.Delete(filename + ".key");
                File.Move(filename + "1" + ".key", filename + ".key");
                File.SetAttributes(filename + ".key", FileAttributes.Hidden);
                File.Move(filename2 + filename1 + "1", filename);
            }
            catch
            {
                MessageBox.Show("Файл поврежден! Переустановите программу или выберите другой файл!");
            }
        }
    }
}

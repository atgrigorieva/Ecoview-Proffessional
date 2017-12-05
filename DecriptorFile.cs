using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Ecoview_Professional
{
    class DecriptorFile
    {
        string filename, pathname;
        public DecriptorFile(ref string filename1, string pathname1)
        {
            this.filename = filename1;
            this.pathname = pathname1;

            FileDecriptor(ref filename);
            filename1 = this.filename;
        }
        public void FileDecriptor(ref string filename)
        {
            FileStream fsFileIn = File.OpenRead(filename);
            // The key
            FileStream fsKeyFile = File.OpenRead(filename + ".key");
            // The decrypted file
            filename = filename.Substring(filename.LastIndexOf(@"\") + 1);

            FileStream fsFileOut = File.Create(pathname + "/" + filename);
            // Prepare the encryption algorithm and read the key from the key file
            TripleDESCryptoServiceProvider cryptAlgorithm = new TripleDESCryptoServiceProvider();
            BinaryReader brFile = new BinaryReader(fsKeyFile);
            cryptAlgorithm.Key = brFile.ReadBytes(24);
            cryptAlgorithm.IV = brFile.ReadBytes(8);

            // The cryptographic stream takes in the unecrypted file
            CryptoStream csEncrypt = new CryptoStream(fsFileIn, cryptAlgorithm.CreateDecryptor(), CryptoStreamMode.Read);

            // Write the new unecrypted file
            StreamReader srCleanStream = new StreamReader(csEncrypt);
            StreamWriter swCleanStream = new StreamWriter(fsFileOut);
            swCleanStream.Write(srCleanStream.ReadToEnd());
            swCleanStream.Close();
            fsFileOut.Close();
            srCleanStream.Close();
            fsKeyFile.Close();
            fsFileIn.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    class EncriptorFileBase64
    {
        string filename, pathname;
        public EncriptorFileBase64(string filename1, string pathname1)
        {
            this.filename = filename1;
            this.pathname = pathname1;

            ToBase64();
        }
        public void ToBase64()
        {
            FileStream fstreamWrite = new FileStream(@filename + "1", FileMode.OpenOrCreate);
            StreamReader fstreamRead = new StreamReader(@filename);
            string text = "";
            
            while (true)
            {
                // Читаем строку из файла во временную переменную.
                string temp = fstreamRead.ReadLine();

                // Если достигнут конец файла, прерываем считывание.
                if (temp == null) break;

                // Пишем считанную строку в итоговую переменную.
                text += temp;
            }
            if (!text.Contains("xml"))
            {
                MessageBox.Show("Файл уже обновлен!");
                return;
            }
            else {
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                string base64 = Convert.ToBase64String(buffer);

                //  fstreamWrite.Write(base64, 0, array.Length);
                fstreamWrite.Close();
                string filename1 = filename.Substring(filename.LastIndexOf(@"\") + 1);
                filename1 = filename1 + "1";
                string filename2 = filename.Remove(filename.LastIndexOf(@"\") + 1);
                File.WriteAllText(filename2 + filename1, base64, Encoding.UTF8);
                fstreamRead.Close();
                File.Delete(@filename);
                File.Move(filename2 + filename1, filename);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ecoview_Professional
{
    class ReadFilePribor
    {
        Ecoview _Analis;
        string filepathRead;
        public ReadFilePribor(string filepath, Ecoview parent)
        {
            this.filepathRead = filepath;
            this._Analis = parent;
            FileReadPribor();
        }
        public void FileReadPribor()
        {
            _Analis.filereadpribor = File.ReadAllLines(filepathRead, Encoding.UTF8);


        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace PadTest1
{
    public class FileOperations
    {
        internal static FileDetails OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files (*.*)|*.*|Text Files (*.txt)|*.txt";
            FileDetails f = new FileDetails();

            if (ofd.ShowDialog() == true)
            {
                StreamReader reader = new StreamReader(ofd.FileName);
                f.file = reader.ReadToEnd();
                reader.Close();
                f.fileName = ofd.FileName;
            }

            return f;
        }

        static internal string SaveFile(string file)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All Files (*.*)|*.*|Text Files (*.txt)|*.txt";
            string fileName = "";

            if (sfd.ShowDialog() == true)
            {
                fileName = sfd.FileName;
                StreamWriter writer = new StreamWriter(fileName);
                writer.Write(file);
                writer.Close();
            }

            return fileName;
        }
    }
}

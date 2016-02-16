using System.IO;
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
                f = OpenFileNoDialog(ofd.FileName);
            }

            return f;
        }

        internal static FileDetails OpenFileNoDialog(string fileName)
        {
            FileDetails f= new FileDetails();
            StreamReader reader = new StreamReader(fileName);
            f.file = reader.ReadToEnd();
            reader.Close();
            f.fileName = fileName;

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
                SaveFileNoDialog(file, fileName);
            }

            return fileName;
        }

        internal static void SaveFileNoDialog(string file, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.Write(file);
            writer.Close();
        }
    }
}

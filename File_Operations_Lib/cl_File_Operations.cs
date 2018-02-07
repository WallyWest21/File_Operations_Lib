using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Operations_Lib
{
    public class cl_File_Operations
    {
        public List<string> SelectFilesToRead()
        {
            List<string> MySelectedFilesToRead = new List<string>();
            System.Windows.Forms.OpenFileDialog MyFileDiaog = new System.Windows.Forms.OpenFileDialog();

            MyFileDiaog.InitialDirectory = @"C:\";
            MyFileDiaog.Title = "Browse Text Files";

            MyFileDiaog.CheckFileExists = true;
            MyFileDiaog.CheckPathExists = true;

            MyFileDiaog.DefaultExt = "txt";
            MyFileDiaog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            //MyFileDiaog.FilterIndex = 2;
            MyFileDiaog.RestoreDirectory = true;

            MyFileDiaog.ReadOnlyChecked = true;
            MyFileDiaog.ShowReadOnly = true;
            MyFileDiaog.Multiselect = true;



            DialogResult result = MyFileDiaog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                foreach (String file in MyFileDiaog.FileNames)
                {
                    MySelectedFilesToRead.Add(file);
                }
            }
            return MySelectedFilesToRead;
        }

        public string SelectFolder()
        {
            System.Windows.Forms.FolderBrowserDialog MyFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            DialogResult result = MyFolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return MyFolderBrowserDialog.SelectedPath;
            }
            return null;
        }


        public void CreateFolder(string FolderPathString)
        {
            if (!System.IO.Directory.Exists(FolderPathString))
            {
                System.IO.Directory.CreateDirectory(FolderPathString);
            }
            else
            { MessageBox.Show("Folder: " + FolderPathString + " already exists!"); }


        }
        public void CreateTxtFile()
        {

        }

        public void DeleteFolder(string FolderPathString)
        {
            if (System.IO.Directory.Exists(FolderPathString))
            {
                System.IO.Directory.Delete(FolderPathString);
            }
            else
            { MessageBox.Show("Folder: " + FolderPathString + " doesn't exists!"); }

        }

        public void DeleteFile(string FilePathString)
        {
            if (System.IO.File.Exists(FilePathString))
            {
                System.IO.File.Delete(FilePathString);
            }
            else
            { MessageBox.Show("File: " + FilePathString + " doesn't exists!"); }

        }

        public void CopyAndPasteFile(string SourceFileName, string SourcePath, string TargetPath, string TargetFileName="", bool OverWriteFile=false)
        {
            string SourceFilePathString = SourcePath + @"\" + SourceFileName;
            if (TargetFileName=="") { TargetFileName = SourceFileName; }
            string TargetFilePathString = TargetPath + @"\" + TargetFileName;

            if (!System.IO.Directory.Exists(TargetPath))
            { CreateFolder(TargetPath); }

                if (System.IO.File.Exists(SourceFilePathString))
            {
                System.IO.File.Copy(SourceFilePathString, TargetFilePathString, OverWriteFile);
            }
            else
            { MessageBox.Show("File: " + SourceFilePathString + " doesn't exists!"); }

        }
        public void CutAndPasteFile(string SourceFileName, string SourcePath, string TargetPath, string TargetFileName = "", bool OverWriteFile = false)
        {
            string SourceFilePathString = SourcePath + @"\" + SourceFileName;
            if (TargetFileName == "") { TargetFileName = SourceFileName; }
            string TargetFilePathString = TargetPath + @"\" + TargetFileName;

            if (!System.IO.Directory.Exists(TargetPath))
            { CreateFolder(TargetPath); }

            if (System.IO.File.Exists(SourceFilePathString))
            {
                System.IO.File.Move(SourceFilePathString, TargetFilePathString);
            }
            else
            { MessageBox.Show("File: " + SourceFilePathString + " doesn't exists!"); }


        }

        public void CopyAndPasteFolder(string SourcePath, string TargetPath, bool OverWriteFile = false)
        {
            if (System.IO.Directory.Exists(SourcePath))
            {
                System.IO.Directory.Move(SourcePath, TargetPath);
            }
            else
            { MessageBox.Show("Folder: " + SourcePath + " doesn't exists!"); }
        }
        public void CutAndPasteFolder(string FilePathString)
        {
            if (System.IO.File.Exists(FilePathString))
            {

            }
            else
            { MessageBox.Show("File: " + FilePathString + " doesn't exists!"); }

        }


        bool ItIsAFile(string FilePathString)
        {

            return false;
        }

        bool ItIsAFolder()
        {
            return false;
        }

        bool ItIsACertainFile(string FileExtension)
        {
            return false;
        }

        double FileSize()
        {
            return 0;
        }

        void WriteListToTextFile(List<object> MyList)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"c:\temp\important.txt", true))
            {
                foreach (object element in MyList)
                {
                    string line = null;
                    foreach (System.Reflection.PropertyInfo propertyInfo in element.GetType().GetProperties()) //https://stackoverflow.com/questions/9893028/c-sharp-foreach-property-in-object-is-there-a-simple-way-of-doing-this
                    {line = line + propertyInfo.GetValue(element).ToString() + ", ";}
                    writer.WriteLine(line.Substring(0, line.Length - 2));
                    //Console.WriteLine(line.Substring(0, line.Length - 2));
                }
            }
        }


    }
}

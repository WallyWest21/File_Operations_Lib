using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test_FileOperations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        File_Operations_Lib.cl_File_Operations cl_IO = new File_Operations_Lib.cl_File_Operations();
        List<user> MyList = new List<user>();

        public MainWindow()
        {
            InitializeComponent();
            MyList.Add(new user {ID=1, Description="bmjg", Name="Ray Ray"});
            MyList.Add(new user { ID = 2, Description = "vbxgh", Name = "Pookie" });
            MyList.Add(new user { ID = 3, Description = "nvbnnv", Name = "Jerome" });
            MyList.Add(new user { ID = 4, Description = "bvnvbnvnvbn", Name = "Dewayne" });
            MyList.Add(new user { ID = 5, Description = "dsggncgfd", Name = "Tyrone" });

            var MyNewlist =( from m in MyList select m).ToList<object>();
            WriteListToTextFile(MyNewlist);

            //foreach (user element in MyList)
            //{
            //    string line = null;
            //     StringBuilder sb = new StringBuilder(); //https://msdn.microsoft.com/en-us/library/hdekwk0b(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2
            //    foreach (PropertyInfo propertyInfo in element.GetType().GetProperties()) //https://stackoverflow.com/questions/9893028/c-sharp-foreach-property-in-object-is-there-a-simple-way-of-doing-this
            //    {
            //        line =line+ propertyInfo.GetValue(element).ToString()+", ";
            //        //sb.AppendFormat("{0},", propertyInfo.GetValue(element));

            //        //Console.WriteLine("{0}, {1}",propertyInfo.Name,propertyInfo.GetValue(element));
            //        //Console.WriteLine(propertyInfo.GetValue(propertyInfo.Name).ToString());

            //        //propertyInfo.Name;
            //        // do stuff here
            //    }
            //    //Console.WriteLine(propertyInfo.GetValue(propertyInfo.Name).ToString());
            //    Console.WriteLine(line.Substring(0,line.Length - 2));

            //}


        }

        void WriteListToTextFile(List <object> MyList)
        {
            using (StreamWriter writer = new StreamWriter(@"c:\temp\important.txt", true))
            {
                foreach (object element in MyList)
                {
                    string line = null;
                    foreach (PropertyInfo propertyInfo in element.GetType().GetProperties()) //https://stackoverflow.com/questions/9893028/c-sharp-foreach-property-in-object-is-there-a-simple-way-of-doing-this
                    {line = line + propertyInfo.GetValue(element).ToString() + ", ";}
                    writer.WriteLine(line.Substring(0, line.Length - 2));
                    Console.WriteLine(line.Substring(0, line.Length - 2));
                }
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (string file in cl_IO.SelectFilesToRead())
            {
                MessageBox.Show(file);
            }
        }

        class user
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}

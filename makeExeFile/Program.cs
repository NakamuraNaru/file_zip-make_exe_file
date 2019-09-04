using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace makeExeFile
{
    class Program
    {
        static void Main(string[] args)
        {
            String company_id = "fasfdsa";  // company unique id
            int month = 3;          // object report month

            // select character code
            Encoding enc = Encoding.GetEncoding("UTF-8");

            // make cs file to move file. For example csv file
            StreamWriter writer = new StreamWriter(@"C:\Users\p000527530\source\repos\makeExeFile\dummy.cs", true, enc);

            // Write text(move file description)
            writer.WriteLine("using System;");
            writer.WriteLine("using System.IO;");
            writer.WriteLine("namespace dummy{");
            writer.WriteLine("class Program{");
            writer.WriteLine("static void Main(string[] args){");
            writer.WriteLine("Console.WriteLine(\"Hello,World!!\");");
            writer.WriteLine("}");
            writer.WriteLine("}");
            writer.WriteLine("}");

            // close file
            writer.Close();

            // set bat file configure
            ProcessStartInfo psInfo = new ProcessStartInfo()
            {
                FileName = @"C:\Users\p000527530\source\repos\makeExeFile\makeExe.bat",    // bat file
                Arguments = $"{company_id} {month}",    // command parameter (argument)
                CreateNoWindow = true,    // コンソール・ウィンドウを開かない
                UseShellExecute = false,  // シェル機能を使用しない
            };

            Process p = Process.Start(psInfo); // execution bat file
            //p.WaitForExit();	// wait process complete

            Console.WriteLine("Finish making exe file");
        }
    }
}

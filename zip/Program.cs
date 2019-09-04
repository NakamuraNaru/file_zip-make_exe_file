using System;
using System.Text;
using System.IO;
//using Ionic.Zip;
using Ionic.Zlib;
using Ionic.Zip;

namespace zip
{
    class Program
    {
        static void Main(string[] args)
        {

            /* Get File Name to do zip */

            String path = @"C:\users\p000527530\Desktop\object_folder";

            var di = new DirectoryInfo(path);

            FileInfo[] files = di.GetFiles("*", SearchOption.AllDirectories);

            String[] fileNameList = new string[0];

            int i = 0;
            /* store file name in array list */
            foreach (FileInfo f in files)
            {
                Array.Resize(ref fileNameList, fileNameList.Length + 1);    // increment element number 
                string fileName = Path.GetFileName(f.FullName);             // Get File Name
                fileNameList[i] = fileName;
                i++;

            }

            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                // 1. ZIP class instance
                using (var zip = new ZipFile(Encoding.GetEncoding("shift_jis")))
                {
                    // 2. Set compression level
                    zip.CompressionLevel = CompressionLevel.BestCompression;

                    // 3. Add File
                    for (i = 0; i < fileNameList.Length; i++) { 
                        zip.AddFile(path+@"\"+fileNameList[i],"");
                    }

                    //Add File(image)
                    //zip.AddFile(@"image path", "画像");

                    // 4. Add directory
                    //zip.AddDirectory(@"C:\you want to add a folder");

                    // 5. Save ZipFile
                    //zip.SaveSelfExtractor(@"C:\users\p000527530\Desktop\sample.exe", SelfExtractorFlavor.WinFormsApplication);
                    zip.Save(path+@"\sample.zip");

                    Console.WriteLine("ZIP make Success");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ZIP make Failed");
                Console.WriteLine(ex.Message);
            }
        }
        //Console.WriteLine("Hello World!");
    }
}

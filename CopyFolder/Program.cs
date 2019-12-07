using System;
using System.IO;

namespace CopyFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"D:\Practise\IMS Project\ims-api\src\YK.IMS.App\YK.IMS.BizLogic\Masters\Colors";
            string targetDirectory = @"D:\Practise\IMS Project\ims-api\src\YK.IMS.App\YK.IMS.BizLogic\Masters\Units";

            Copy(sourceDirectory, targetDirectory);

            Console.WriteLine("\r\nEnd of program");
            Console.ReadKey();
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name.Replace("Color", "Unit")), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
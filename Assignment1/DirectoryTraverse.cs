using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class DirectoryTraverse
    {
        private List<string> sampleList = new List<string>();
        public List<string> Walk(String path)
        {
            
            string[] list = Directory.GetDirectories(path);


            if (list == null) return null;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    Walk(dirpath);
                    //Console.WriteLine("Dir:" + dirpath);
                }
            }
            //Console.WriteLine("extra");
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                if (filepath.EndsWith("csv"))
                {
                     sampleList.Add(filepath);
                }
                //Console.WriteLine("File:" + filepath);
            }
            return sampleList;
        }
    }
}

using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class DirectoryTraverse
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private List<string> sampleList = new List<string>();
        Exception exp = new Exception();
        public List<string> Walk(String path)
        {
            string[] dirlist= exp.checkDirectory(path);

            foreach (string dirpath in dirlist)
            {
                if (Directory.Exists(dirpath))
                {
                    Walk(dirpath); // For checking the directories 
                }
            }

            sampleList = exp.CheckFile(path);
            
            return sampleList;
        }
    }
}

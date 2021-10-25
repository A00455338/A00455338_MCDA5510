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
    public class Exception
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public List<string> csvFiles = new List<string>();
        private string[] list=null;
        public string[] checkDirectory (string path)
        {
            try
            {
                list = Directory.GetDirectories(path);
            }
            catch (DirectoryNotFoundException)
            {
                log.Error("The directory cannot be found.");
            }
            return list;
        }
        public List<string> CheckFile(string path)
        {
            if (list == null) return null;

            if (path is null)
            {
                log.Error("You did not supply a file path.");
                return null;
            }

            try
            {
                string[] fileList = Directory.GetFiles(path);
                foreach (string filepath in fileList)
                {
                    if (filepath.EndsWith("csv"))
                    {
                        csvFiles.Add(filepath);
                    }
                    else
                    {
                        throw new FileNotFoundException(filepath);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                log.Error("The csv file is not found File Name : - "+ e.Message);
            }
            
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Console.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Console.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            return csvFiles;
        }

    }


}


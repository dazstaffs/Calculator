using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator.Domain.Classes
{
    public static class FileLoader
    {
        public static string[] GetInstructions(string FilePath)
        {
            List<string> list = new List<string>();
            using (var steamReader = new StreamReader(FilePath))
            {
                string line;
                while ((line = steamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            return list.ToArray();
        }

        public static void CheckFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The instruction file could not be found");
            }
        }
    }
}

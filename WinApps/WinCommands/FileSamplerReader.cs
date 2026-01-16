using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCommands
{
    public static class FileSamplerReader
    {
        public static List<string> GetFileSample(FindStrSingleResult result, int size = 10) 
        {
            if (string.IsNullOrEmpty(result.FilePath))
                return new List<string>();

            var content = System.IO.File.ReadAllLines(result.FilePath);

            int linesNumber = size * 2 + 1;

            int initialPart = int.Parse(result.Line) - size;
            initialPart = initialPart < 0 ? 0: initialPart;


            var partialContent = content;
            if(initialPart > 0)
            {
                partialContent = partialContent.Skip(initialPart - 1).ToArray();
            }

            if(partialContent.Count() < linesNumber)
            {
                return partialContent.ToList();
            }

            List<string> fileSample = new List<string>();
            int fileIndex = initialPart + 1;
            foreach(var sourceTextLine in partialContent.Take(linesNumber))
            {
                string newLine = $"{fileIndex.ToString("D3")}:   {sourceTextLine}";
                fileSample.Add(newLine);
                fileIndex++;
            }

            return fileSample;
        }
    }
}

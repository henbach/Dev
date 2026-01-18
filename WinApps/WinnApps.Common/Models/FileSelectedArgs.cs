using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnApps.Common.Models
{
    public class FileSelectedArgs
    {
        public string Path { get; set; }
        public int Line { get; set; }

        public FileSelectedArgs(string path, int line)
        {
            Path = path;
            Line = line;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCommands
{
    public static class WinCommandBuilder
    {
        public static string GetFindStr(string path, string toSearch, string filter="", string options ="")
        {
            string commandOptions = "/n /s /i /c:";
            if(string.IsNullOrEmpty(options) == false)
            {
                commandOptions = options;
            }

            string commandFilter = "*.*";
            if(string.IsNullOrEmpty(filter) == false)
            { 
                commandFilter = filter; 
            }

            string commandPath = string.Empty;
            if (string.IsNullOrEmpty(path) == false)
            {
                commandPath = path;
                commandPath += @"\" + commandFilter;
            }
            else
            {
                commandPath = commandFilter;
            }

            return $"{commandOptions}\"{toSearch}\"  \"{commandPath}\" ";

        }

    }
}

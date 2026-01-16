using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCommands
{
    public class OpenFileService
    {
        public void RequestService(string path, string line)
        {
            string commandParameters = $"/c start \"\" \"{path}\"";
            if (path.EndsWith(".pas"))
            {
                commandParameters = $"/c start \"\" \"" + @"C:\Portable\PortableApps\PortableApps\Notepad++Portable\App\Notepad++\notepad++.exe" + $"\" -n{line} \"{path}\"";
            }
            var winCommandResult = CommandRunner.RunCommand("cmd.exe", commandParameters);
            
        }
    }
}

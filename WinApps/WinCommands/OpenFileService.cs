using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinnApps.Common.Models;

namespace WinCommands
{
    public class OpenFileService
    {
        public void RequestService(FileSelectedArgs args)
        {
            string commandParameters = $"/c start \"\" \"{args.Path}\"";
            if (args.Path.EndsWith(".pas") || args.Path.EndsWith(".cs"))
            {
                commandParameters = $"/c start \"\" \"" + @"C:\Portable\PortableApps\PortableApps\Notepad++Portable\App\Notepad++\notepad++.exe" + $"\" -n{args.Line} \"{args.Path}\"";
            }
            var winCommandResult = CommandRunner.RunCommand("cmd.exe", commandParameters);
            
        }
    }
}

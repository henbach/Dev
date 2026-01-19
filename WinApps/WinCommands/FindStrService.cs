using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinCommands
{
    public class FindStrService
    {
        public FindStrService() { }

        public async Task<List<FindStrSingleResult>> RequestServiceAsync(string path, string textToSearch,int linesToShow, string fileExtension)
        {
            var commandParameters = WinCommandBuilder.GetFindStr(path, textToSearch, fileExtension);
            var winCommandResult = await Task.Run(()=> CommandRunner.RunCommand("findstr", commandParameters));
            return FindStrSingleResult.GetFindStrResults(winCommandResult, textToSearch, linesToShow);
        }
    }
}

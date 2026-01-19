namespace WinCommands
{
    public class FindStrSingleResult
    {
        public string OriginalLine { get; set; }

        public int LinesNumberToExtract { get; set; } = 1;

        public string TextToSearch { get; set; }

        public FindStrSingleResult(string originalLine, int linesToShow)
        {
            OriginalLine = originalLine;
            LinesNumberToExtract = linesToShow; 
        }

        public string FilePath
        {
            get
            {
                if (OriginalLine.Split(':').Count() < 2)
                    return string.Empty;

                return OriginalLine.Split(':')[0] +":" + OriginalLine.Split(':')[1];
            }
        }

        public string Line
        {
            get
            {
                if(OriginalLine.Split(':').Count() < 3)
                    return string.Empty;

                return OriginalLine.Split(':')[2];
            }
        }

        public List<string> FileExtract
        {
            get
            {
                return FileSamplerReader.GetFileSample(this, LinesNumberToExtract);
            }            
        }

        public string Sample
        {
            get
            {
                if (OriginalLine.Split(':').Count() < 4)
                    return string.Empty;

                return OriginalLine.Split(':')[3];
            }
        }

        public static List<FindStrSingleResult> GetFindStrResults(WinCommandOutput wcouts, string textToSearch, int linesToShow = 1)
        {
            List<FindStrSingleResult> findStrs = new List<FindStrSingleResult>();
            foreach(var item in wcouts.Output.Split("\r\n"))
            {
                var sr = new FindStrSingleResult(item, linesToShow);
                sr.TextToSearch = textToSearch;
                findStrs.Add(sr);
            }
            return findStrs;
        }

    }
}

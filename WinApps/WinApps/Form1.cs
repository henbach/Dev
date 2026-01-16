using WinCommands;

namespace WinApps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.tbFilesExtension.Text = "*.*";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string path = this.tbPath.Text;
            string textToSearch = this.tbWordToSearch.Text;
            string fileExtension = this.tbFilesExtension.Text;

            string commandText = WinCommands.WinCommandBuilder.GetFindStr(path, textToSearch, fileExtension);
            var results = CommandRunner.RunCommand("findstr", commandText);

            if (results != null)
            {
                var output = results.Output.Split("\r\n");
                this.lbResults.Items.Clear();
                this.lbResults.Items.AddRange(output);                
            }

        }
    }
}

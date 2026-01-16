namespace WinApps
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tbPath = new TextBox();
            label2 = new Label();
            tbWordToSearch = new TextBox();
            label3 = new Label();
            tbFilesExtension = new TextBox();
            btnSearch = new Button();
            lbResults = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 0;
            label1.Text = "Path:";
            // 
            // tbPath
            // 
            tbPath.Location = new Point(52, 25);
            tbPath.Name = "tbPath";
            tbPath.Size = new Size(482, 23);
            tbPath.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 65);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 2;
            label2.Text = "Phrase to search";
            // 
            // tbWordToSearch
            // 
            tbWordToSearch.Location = new Point(111, 62);
            tbWordToSearch.Name = "tbWordToSearch";
            tbWordToSearch.Size = new Size(423, 23);
            tbWordToSearch.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 100);
            label3.Name = "label3";
            label3.Size = new Size(151, 15);
            label3.TabIndex = 4;
            label3.Text = "Type of Files to be searched";
            // 
            // tbFilesExtension
            // 
            tbFilesExtension.Location = new Point(169, 97);
            tbFilesExtension.Name = "tbFilesExtension";
            tbFilesExtension.Size = new Size(365, 23);
            tbFilesExtension.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(540, 25);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(144, 95);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lbResults
            // 
            lbResults.FormattingEnabled = true;
            lbResults.Location = new Point(12, 145);
            lbResults.Name = "lbResults";
            lbResults.Size = new Size(1145, 289);
            lbResults.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1169, 450);
            Controls.Add(lbResults);
            Controls.Add(btnSearch);
            Controls.Add(tbFilesExtension);
            Controls.Add(label3);
            Controls.Add(tbWordToSearch);
            Controls.Add(label2);
            Controls.Add(tbPath);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbPath;
        private Label label2;
        private TextBox tbWordToSearch;
        private Label label3;
        private TextBox tbFilesExtension;
        private Button btnSearch;
        private ListBox lbResults;
    }
}

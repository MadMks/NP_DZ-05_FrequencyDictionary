namespace FrequencyDictionary
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUrl = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonParse = new System.Windows.Forms.Button();
            this.listBoxDictionary = new System.Windows.Forms.ListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBarLoadWords = new System.Windows.Forms.ToolStripProgressBar();
            this.progressBarLoadPage = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelLoadPage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLoadWords = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelEmpty = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(13, 23);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(24, 13);
            this.labelUrl.TabIndex = 0;
            this.labelUrl.Text = "Url:";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(43, 20);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(404, 21);
            this.textBoxUrl.TabIndex = 1;
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(454, 19);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(75, 23);
            this.buttonParse.TabIndex = 2;
            this.buttonParse.Text = "Парсить";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // listBoxDictionary
            // 
            this.listBoxDictionary.FormattingEnabled = true;
            this.listBoxDictionary.Location = new System.Drawing.Point(14, 53);
            this.listBoxDictionary.Name = "listBoxDictionary";
            this.listBoxDictionary.Size = new System.Drawing.Size(515, 225);
            this.listBoxDictionary.TabIndex = 4;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLoadPage,
            this.progressBarLoadPage,
            this.toolStripStatusLabelEmpty,
            this.toolStripStatusLabelLoadWords,
            this.progressBarLoadWords});
            this.statusStrip.Location = new System.Drawing.Point(0, 294);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(544, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // progressBarLoadWords
            // 
            this.progressBarLoadWords.Name = "progressBarLoadWords";
            this.progressBarLoadWords.Size = new System.Drawing.Size(100, 16);
            // 
            // progressBarLoadPage
            // 
            this.progressBarLoadPage.Name = "progressBarLoadPage";
            this.progressBarLoadPage.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabelLoadPage
            // 
            this.toolStripStatusLabelLoadPage.Name = "toolStripStatusLabelLoadPage";
            this.toolStripStatusLabelLoadPage.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabelLoadPage.Text = "Загрузка страницы:";
            // 
            // toolStripStatusLabelLoadWords
            // 
            this.toolStripStatusLabelLoadWords.Name = "toolStripStatusLabelLoadWords";
            this.toolStripStatusLabelLoadWords.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabelLoadWords.Text = "Загрузка слов:";
            // 
            // toolStripStatusLabelEmpty
            // 
            this.toolStripStatusLabelEmpty.Name = "toolStripStatusLabelEmpty";
            this.toolStripStatusLabelEmpty.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabelEmpty.Text = "        ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 316);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.listBoxDictionary);
            this.Controls.Add(this.buttonParse);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.labelUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Частотный словарь";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.ListBox listBoxDictionary;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBarLoadWords;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLoadPage;
        private System.Windows.Forms.ToolStripProgressBar progressBarLoadPage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEmpty;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLoadWords;
    }
}


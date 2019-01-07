using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrequencyDictionary
{
    public partial class MainForm : Form
    {
        private Dictionary<string, int> wordCountPairs = null;

        public string RequestUriString
        {
            get
            {
                if (this.IsThereProtocol(this.textBoxUrl.Text))
                {
                    return this.textBoxUrl.Text;
                }

                return CreateUriWithProtocol(this.textBoxUrl.Text);
            }
        }

        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.progressBarLoadPage.Style = ProgressBarStyle.Blocks;
            this.progressBarLoadWords.Step = 1;

            this.Shown += MainForm_Shown;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.textBoxUrl.Focus();
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            this.listBoxDictionary.Items.Clear();
            this.progressBarLoadWords.Value = 0;

            if (this.IsUriCorrect())
            {
                Task.Factory.StartNew(() => ParsingUriPage());
            }
        }

        private void ParsingUriPage()
        {
            this.Invoke(new Action(() => {
                this.buttonParse.Enabled = false;
                this.listBoxDictionary.UseWaitCursor = true;
            }));

            wordCountPairs = new Dictionary<string, int>();
            string page = GetPageText();
            string pattern = @">(?!#|[ ]|\.)(.[^(<|>)]*)<";

            MatchCollection matchCollection = Regex.Matches(page, pattern);
            // Установка максимума прогресБара.
            this.statusStrip.Invoke(new Action(() =>
            {
                this.progressBarLoadWords.Maximum = matchCollection.Count;
            }));
            // Идем по предложениям.
            foreach (Match match in matchCollection)
            {
                string allString = match.Groups[1].Value.ToString();
                string splits = ".,:;-()!?\t \"\'_&";
                string[] words = allString.Split(splits.ToCharArray());

                // Добавления каждого слова в предложении.
                AddEachWord(words);

                this.statusStrip.Invoke(new Action(() => { this.progressBarLoadWords.PerformStep(); }));
            }

            this.listBoxDictionary.Invoke(new Action(AddWordsToList));


            this.Invoke(new Action(() => {
                this.buttonParse.Enabled = true;
                this.listBoxDictionary.UseWaitCursor = false;
                this.textBoxUrl.Focus();
            }));
        }

        /// <summary>
        /// Добавления каждого слова в предложении.
        /// </summary>
        /// <param name="words">Предложени/строка/слово.</param>
        private void AddEachWord(string[] words)
        {
            foreach (string w in words)
            {
                string word = w.Trim();
                word = word.ToLower();

                if (!this.IsWord(word))
                {
                    continue;
                }

                CountRepeatedWords(word);
            }
        }

        /// <summary>
        /// Считаем слова.
        /// </summary>
        /// <param name="word">Слово.</param>
        private void CountRepeatedWords(string word)
        {
            if (!wordCountPairs.Keys.Contains(word))
            {
                wordCountPairs[word] = 0;
            }
            wordCountPairs[word] = ++wordCountPairs[word];
        }

        /// <summary>
        /// Получить текст запрашиваемой страницы.
        /// </summary>
        /// <returns>Текст страницы (указанной в textBox)</returns>
        private string GetPageText()
        {
            this.statusStrip.Invoke(new Action(() => 
            {
                this.progressBarLoadPage.Style = ProgressBarStyle.Marquee;
            }));

            HttpWebRequest request = WebRequest.Create(RequestUriString) as HttpWebRequest;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

            string page = reader.ReadToEnd();

            reader.Close();


            this.statusStrip.Invoke(new Action(() =>
            {
                this.progressBarLoadPage.Style = ProgressBarStyle.Blocks;
            }));

            return page;
        }

        /// <summary>
        /// Добавить слова в listBox.
        /// </summary>
        private void AddWordsToList()
        {
            // Сортируем по значению.
            var sorted = wordCountPairs.OrderByDescending(x => x.Value);

            foreach (KeyValuePair<string, int> item in sorted)
            {
                this.listBoxDictionary.Items.Add(item.Key + " : " + item.Value);
            }
        }

        private bool IsWord(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                return false;
            }

            if (Int32.TryParse(word, out int i))
            {
                return false;
            }

            return true;
        }

        private bool IsUriCorrect()
        {
            if (String.IsNullOrEmpty(textBoxUrl.Text))
            {
                MessageBox.Show("Поле ссылки пустое!", "Пусто");

                return false;
            }
            else if (textBoxUrl.Text.Length < 4)
            {
                MessageBox.Show("Ссылка некорректная!", "Ошибка");

                return false;
            }

            return true;
        }

        private string CreateUriWithProtocol(string uriStr)
        {
            uriStr = uriStr.Insert(0, "http://");

            return uriStr;
        }

        private bool IsThereProtocol(string uriStr)
        {
            if (uriStr.StartsWith("http://") || uriStr.StartsWith("https://"))
            {
                return true;
            }

            return false;
        }
    }
}

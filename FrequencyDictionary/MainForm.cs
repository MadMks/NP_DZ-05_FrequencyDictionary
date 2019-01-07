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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrequencyDictionary
{
    public partial class MainForm : Form
    {
        private SortedDictionary<string, int> wordCountPairs = null;

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

            // HACK: dev
            //this.toolStripProgressBar.Style = ProgressBarStyle.Blocks;
            //this.ParsingUriPage();
            Task.Factory.StartNew(() => ParsingUriPage());
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            if (this.IsUriCorrect())
            {
                //this.ParsingUriPage();
            }
        }

        private void ParsingUriPage()
        {
            // HACK: dev
            this.textBoxUrl.Invoke(new Action(() => { this.textBoxUrl.Text = "https://www.google.com.ua/"; }));

            

            wordCountPairs = new SortedDictionary<string, int>();
            string page = GetPageText();
            string pattern = @">(?!#|[ ]|\.)(.[^(<|>)]*)<";

            MatchCollection matchCollection = Regex.Matches(page, pattern);
            foreach (Match match in matchCollection)
            {
                string allString = match.Groups[1].Value.ToString();
                string splits = ".,:;-()!?\t \"\'_&";
                string[] words = allString.Split(splits.ToCharArray());

                foreach (string w in words)
                {
                    string word = w.Trim();
                    word = word.ToLower();

                    if (!this.IsWord(word))
                    {
                        continue;
                    }

                    CountRepeatedWords(word);

                    this.statusStrip.Invoke(new Action(() => { this.toolStripProgressBar.PerformStep(); }));
                }
            }

            this.listBoxDictionary.Invoke(new Action(AddWordsToList));
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
            HttpWebRequest request = WebRequest.Create(RequestUriString) as HttpWebRequest;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

            string page = reader.ReadToEnd();

            reader.Close();
            return page;
        }

        /// <summary>
        /// Добавить слова в listBox.
        /// </summary>
        private void AddWordsToList()
        {
            foreach (KeyValuePair<string, int> item in wordCountPairs)
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

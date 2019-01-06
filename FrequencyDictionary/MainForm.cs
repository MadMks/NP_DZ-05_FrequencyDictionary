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
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            if (this.IsUriCorrect())
            {
                //HttpWebRequest request = WebRequest.Create(RequestUriString) as HttpWebRequest;

                //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //StreamReader reader = new StreamReader(
                //    response.GetResponseStream());
                //textBoxDictionary.Text = reader.ReadToEnd();
                //string page = reader.ReadToEnd();

                WebClient webClient = new WebClient();
                byte[] data = webClient.DownloadData(RequestUriString);
                string page = Encoding.Default.GetString(data);
                
                string pattern = ">(.[^(<|>)]*)<";

                MatchCollection matchCollection = Regex.Matches(page, pattern); 
                foreach (Match match in matchCollection)
                {
                    //Console.WriteLine(match.Groups[1].Value);// тут каждая строка
                    string allString = match.Groups[1].Value.ToString();
                    string splits = ".,:;-()!?\t \"\'_&";
                    string[] words = allString.Split(splits.ToCharArray());

                    foreach (string word in words)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
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

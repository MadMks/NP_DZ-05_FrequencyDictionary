using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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

        private string CreateUriWithProtocol(string uriStr)
        {
            throw new NotImplementedException();
        }

        private bool IsThereProtocol(string uriStr)
        {
            if (uriStr.StartsWith("http://") || uriStr.StartsWith("https://"))
            {
                return true;
            }

            return false;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            // TODO: проверить введенный Url
            if (this.IsUriCorrect())
            {
                HttpWebRequest request = WebRequest.Create(RequestUriString) as HttpWebRequest;

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(
                    response.GetResponseStream());
                textBoxDictionary.Text = reader.ReadToEnd();
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
    }
}

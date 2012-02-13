using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SOAPI2
{
    public partial class OAuthForm : Form
    {
        private void DisplayHtml(string html)
        {
            webBrowser1.Navigate("about:blank");
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
            webBrowser1.DocumentText = html;
        }

        public OAuthForm()
        {
            InitializeComponent();
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            
            

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string html = File.ReadAllText("oauth.htm");
            DisplayHtml(html);
        }
        void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Console.WriteLine(e.Url.ToString());
            var match = Regex.Match(e.Url.ToString(), "https://stackexchange.com/oauth/login_success#access_token=.?&expires=\\d+");
            if(match.Success)
            {
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace OtelOtomasyonu
{
    public partial class Haberler : Form
    {
        public Haberler()
        {
            InitializeComponent();
        }

        ChromiumWebBrowser chrome;

        private void Haberler_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();

            if (Cef.IsInitialized == false)
            {
                Cef.Initialize(settings);
                chrome = new ChromiumWebBrowser("");
                chrome.BackColor = Color.Aquamarine;
                chrome.Dock = DockStyle.Fill;
            }
            this.pnlHaber.Controls.Add(chrome);



        }

        private void beşiktaşJKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chrome.Load("http://www.bjk.com.tr/tr");
        }

        private void haber1903ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chrome.Load("http://haber1903.com/");
        }

        private void karakartalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chrome.Load("http://www.karakartal.com/");
        }

        private void ajansBeşiktaşToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chrome.Load("http://www.ajansbesiktas.com/");


        }

        private void haberKartalıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chrome.Load("http://www.haberkartali.org/");
        }

        private void kartalYuvasıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chrome.Load("https://www.kartalyuvasi.com.tr/");
        }
    }
}

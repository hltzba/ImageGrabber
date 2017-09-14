using FSLib.Network.Http;
using HtmlAgilityPack;
using ImageGrabber.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageGrabber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string PlateUrl = "http://c.n.h.k.xbluntan.space/forum-157-1.html";
            HttpClient NetworkClient = new HttpClient();
            var ctx = NetworkClient.Create<string>(HttpMethod.Get, PlateUrl).Send();
            if (!ctx.IsValid())
            {
                MessageBox.Show("无效获取");
                return;
            }

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(ctx.Result);

            // var nodes = doc.DocumentNode.SelectNodes("//*[@id='normalthread_*']/tr[1]/th/a[2]");

            var nodes = doc.DocumentNode.SelectNodes("//*[contains(@id,'normalthread_')]/tr[1]/th/a[2]");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (var item in nodes)
                {
                    string href = item.GetAttributeValue("href", "");
                    listView1.Items.Add("http://c.n.h.k.xbluntan.space/" + href);
                    // textBox1.AppendText("http://c.n.h.k.xbluntan.space/" + href + "\r\n");
                }
            }
        }
    }
}
﻿using FSLib.Network.Http;
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

            //获取帖子集合
            var nodes = doc.DocumentNode.SelectNodes("//*[contains(@id,'normalthread_')]/tr[1]/th/a[2]");
            if (nodes != null && nodes.Count > 0)
            {
                foreach (var item in nodes)
                {
                    string href = item.GetAttributeValue("href", "");
                    string title = item.InnerText;
                    if (!title.Contains("P】"))
                    {
                        continue;
                    }
                    int i = dataGridView1.Rows.Add();
                    var row = dataGridView1.Rows[i];
                    string id = "";
                    string[] hrefsplit = href.Split('-');
                    if (hrefsplit != null && hrefsplit.Length > 2)
                    {
                        id = hrefsplit[1];
                    }
                    row.Cells["colTitle"].Value = id + title;
                    row.Cells["colUrl"].Value = "http://c.n.h.k.xbluntan.space/" + href;
                    // listView1.Items.Add("http://c.n.h.k.xbluntan.space/" + href);
                    // textBox1.AppendText("http://c.n.h.k.xbluntan.space/" + href + "\r\n");
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string url = dataGridView1.Rows[e.RowIndex].Cells["colUrl"].Value.ToString();
            HttpClient NetworkClient = new HttpClient();
            var ctx = NetworkClient.Create<string>(HttpMethod.Get, url).Send();
            if (!ctx.IsValid())
            {
                MessageBox.Show("无效获取");
                return;
            }

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(ctx.Result);
            var nodes = doc.DocumentNode.SelectNodes("//*[contains(@id,'aimg_')]");
            if (nodes != null && nodes.Count > 0)
            {
                var imgsrc = nodes[0].GetAttributeValue("file", "");
                if (string.IsNullOrEmpty(imgsrc))
                {
                    MessageBox.Show("未获取到图片");
                }
                else
                {
                    HttpClient ImgClient = new HttpClient();
                    var img = NetworkClient.Create<Image>(HttpMethod.Get, imgsrc).Send();
                    if (!ctx.IsValid())
                    {
                        MessageBox.Show("无效获取");
                        return;
                    }
                    pictureBox1.Image = img.Result;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGrabber.Grabber.GrabberEquips
{
    using System.ComponentModel.Composition;
    using System.Text.RegularExpressions;
    using DB;
    using System.ComponentModel;

    [Export(typeof(INewsGrabber))]
    internal class LifeSelfieGrabber : GrabberBase, INewsGrabber
    {
        public string Url { get { return "http://c.n.h.k.xbluntan.space/forum-157-1.html"; } }

        public string Name
        {
            get
            {
                return "生活自拍";
            }
        }

        private Dictionary<PostDesc, BackgroundWorker> getpicworks = new Dictionary<PostDesc, BackgroundWorker>();

        public List<PostDesc> GetPostItem()
        {
            var doc = GetDocument(Url);
            if (doc == null)
                return null;
            List<PostDesc> rel = new List<PostDesc>();
            var nodes = doc.DocumentNode.SelectNodes("//*[contains(@id,'normalthread_')]/tr[1]/th/a[2]");
            foreach (var item in nodes)
            {
                PostDesc p = new PostDesc();
                string href = item.GetAttributeValue("href", "");
                string title = item.InnerText;
                if (!title.Contains("P】"))
                {
                    continue;
                }

                string id = "";
                string[] hrefsplit = href.Split('-');
                if (hrefsplit != null && hrefsplit.Length > 2)
                {
                    id = hrefsplit[1];
                }
                p.Id = Convert.ToInt32(id);
                p.Title = title;
                p.Url = "http://c.n.h.k.xbluntan.space/" + href;
                BackgroundWorker works = new BackgroundWorker();
                //getpicworks.Add(p,)
                rel.Add(p);
            }
            return rel;
        }

        public void SavePic(List<PostDesc> postinfos)
        {
            //   Parallel.ForEach(postinfos, ParallelOptions.)
        }
    }
}
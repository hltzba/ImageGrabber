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

    [Export(typeof(INewsGrabber))]
    internal class LifeSelfieGrabber : GrabberBase, INewsGrabber
    {
        private string PlateUrl = "http://c.n.h.k.xbluntan.space/forum-157-1.html";

        public string Name
        {
            get
            {
                return "生活自拍";
            }
        }

        public PostItem[] GetLatest(string[] keywords)
        {
            var doc = GetDocument(PlateUrl);
            if (doc == null)
                return null;

            var nodes = doc.DocumentNode.SelectNodes("//div[@class='newsList']/a[2]");
            return null;
        }
    }
}
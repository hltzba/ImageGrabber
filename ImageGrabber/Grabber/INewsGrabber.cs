using ImageGrabber.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGrabber.Grabber
{
    public interface INewsGrabber
    {
        string Name { get; }

        string Url { get; }

        List<PostDesc> GetPostItem();

        void SavePic(List<PostDesc> postinfos);
    }
}
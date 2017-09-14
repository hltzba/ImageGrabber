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

        /// <summary>
        /// 获得最新的记录
        /// </summary>
        /// <param name="keywords"></param>
        /// <returns></returns>
        PostItem[] GetLatest(string[] keywords);
    }
}
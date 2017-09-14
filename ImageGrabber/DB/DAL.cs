using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGrabber.DB
{
    public static class DAL
    {
        private static ImageGrabberDbContext db;

        static DAL()
        {
            db = new ImageGrabberDbContext();
        }

        public static List<PostDesc> GetPostList()
        {
            return db.BBSPost.ToList();
        }

        public static List<PostImage> GetPostImages(int postId)
        {
            return db.BBSPostDetails.Where(it => it.PostId == postId).ToList();
        }
    }
}
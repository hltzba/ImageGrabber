using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGrabber.DB
{
    public class ImageGrabberDbContext : DbContext
    {
        public ImageGrabberDbContext() : base("name=ImageGrabberContext")
        { }

        public DbSet<PostDesc> BBSPost { get; set; }

        public DbSet<PostImage> BBSPostDetails { get; set; }
    }
}
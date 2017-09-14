using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGrabber.DB
{
    public class PostImage
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string ImagePath { get; set; }
    }
}
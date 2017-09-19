using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGrabber.DB
{
    /// <summary>
    /// 图片信息
    /// </summary>
    public class PostImage
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }

        public string ImagePath { get; set; }
    }
}
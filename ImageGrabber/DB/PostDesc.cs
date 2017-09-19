using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGrabber.DB
{
    /// <summary>
    /// 帖子信息
    /// </summary>
    public class PostDesc
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Desc { get; set; }
    }
}
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.LatestVideosViewModels
{
    public class ListLatestVideo

    {
        public string Author { get; set; }
        public string Link { get; set; }
        [Display(Name = "نشر في")]
        public DateTime PubDate { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }

      

    }
}

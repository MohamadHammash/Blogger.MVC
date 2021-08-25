using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.VideosViewModels
{
    public class ListVideosViewModel
    {
        public Guid Id { get; set; }
       
        [Display(Name = "عنوان الفيديو")]
        public string Title { get; set; }

        [Display(Name = "رابط الفيديو")]
        public string URL { get; set; }
        [Display(Name = "نشر في")]
        public DateTime PublishingDate { get; set; }
        [Display(Name = "قائمة التشغيل")]
        public Guid VideosListId { get; set; }

        // Nav prop
        public VideosList VideosList { get; set; }
    }
}

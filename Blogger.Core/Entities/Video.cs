﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Entities
{
  public class Video
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="الرجاء كتابة عنوان الفيديو")]
        [Display(Name ="عنوان الفيديو")]
        public string Title { get; set; }
        [Required(ErrorMessage ="الرجاء اضافة رابط الفيديو")]
        [Display(Name = "رابط الفيديو")]
        [Url(ErrorMessage = "رابط غير صالح")]
        [StringLength(50, MinimumLength = 18 ,ErrorMessage ="الرابط متكون من 18 خانة على الأقل")]
        public string URL { get; set; }
        [Display(Name = "نشر في ")]
        [DisplayFormat(DataFormatString = "yyyy-mm-dd:HH:MM")]
        public DateTime PublishingDate { get; set; }
        public Guid VideosListId { get; set; }

        // Nav prop
        public VideosList VideosList { get; set; }

    }
}

using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.VideosViewModels
{
    public class CreateVideoViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "الرجاء كتابة عنوان الفيديو")]
        [Display(Name = "عنوان الفيديو")]
        public string Title { get; set; }
        [Required(ErrorMessage = "الرجاء اضافة رابط الفيديو")]
        [Display(Name = "رابط الفيديو")]
        [Url(ErrorMessage = "رابط غير صالح")]
        [StringLength(50, MinimumLength = 18, ErrorMessage = "الرابط متكون من 18 خانة على الأقل")]
        public string URL { get; set; }
        [Display(Name = "نشر في")]
        public DateTime PublishingDate { get; set; }
        [Display(Name = "قائمة التشغيل")]

        public Guid? VideosListId { get; set; }

        // Nav prop
        public VideosList VideosList { get; set; }
    }
}

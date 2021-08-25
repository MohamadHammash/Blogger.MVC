using Microsoft.AspNetCore.Http;
using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.PostingCardsViewModels
{
    public class CreatePostingCardViewModel
    {
        public Guid Id { get; set; }
        [Display(Name ="العنوان")]
        public string Header { get; set; }
        [Display(Name = "المحتوى")]

        public string Content { get; set; }
        [Required(ErrorMessage = "الرجاء تحميل صورة")]
        [Display(Name = "الصورة")]
        public IFormFile Photo { get; set; }

        [Display(Name = "تاريخ النشر")]
        public DateTime PublishingDate { get; set; }
        

    }
}

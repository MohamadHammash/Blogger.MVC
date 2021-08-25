using Blogger.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Ui.Models.ViewModels.PostingCardsViewModels
{
    public class EditPostingCardViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "العنوان")]
        public string Header { get; set; }
        [Display(Name = "المحتوى")]
        public string Content { get; set; }
        [Display(Name = "الصورة")]
        public string ImagePath { get; set; }

        [Display(Name = "تاريخ النشر")]
        public DateTime PublishingDate { get; set; }
 
    }
}
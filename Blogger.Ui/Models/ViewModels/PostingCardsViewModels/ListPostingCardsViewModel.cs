using Blogger.Core.Entities;
using Blogger.Ui.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Blogger.Ui.Models.ViewModels.PostingCardsViewModels
{
    public class ListPostingCardsViewModel
    {
      
        public Guid Id { get; set; }
        [Display(Name = "العنوان")]
        public string Header { get; set; }
        [Display(Name = "المحتوى")]
        public string Content { get; set; }
        public string StrippedContent => StripHtml.StripHTML(Content);
        [Display(Name = "الصورة")]
        public string ImagePath { get; set; }

        [Display(Name = "تاريخ النشر")]
        public DateTime PublishingDate { get; set; }
        public bool New => (DateTime.Now - PublishingDate).TotalDays <= 2 ? true : false;






    }
}
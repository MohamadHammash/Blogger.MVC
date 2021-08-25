using Blogger.Core.Entities;
using Blogger.Ui.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.PostingCardsViewModels
{
    public class DeletePostingCardViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "العنوان")]
        public string Header { get; set; }
        [Display(Name = "المحتوى")]
        public string Content { get; set; }
        [Display(Name = "المحتوى")]
        public string StrippedContent => StripHtml.StripHTML(Content);

        [Display(Name = "الصورة")]
        public string ImagePath { get; set; }

        [Display(Name = "تاريخ النشر")]
        public DateTime PublishingDate { get; set; }
   

    }
}

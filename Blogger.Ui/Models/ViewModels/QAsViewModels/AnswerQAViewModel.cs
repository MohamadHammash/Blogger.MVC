using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.QAsViewModels
{
    public class AnswerQAViewModel
    {
        public Guid Id { get; set; }
       
        [Display(Name = "الاسم")]
        public string FirstName { get; set; }
       
        [Display(Name = "الكنية")]
        public string LastName { get; set; }
     
        [Display(Name = "موضوع السؤال")]
        public string Subject { get; set; }
       
        [Display(Name = "السؤال")]
        public string Question { get; set; }
       [Required(ErrorMessage = "الرجاء تعبئة الحقل")]
        [Display(Name = "الإجابة")]
        public string Answer { get; set; }
        [Display(Name ="نشر في ")]
        public DateTime PublishingDate { get; set; }
        //public string Initials => $"{FirstName.FirstOrDefault()} {LastName.FirstOrDefault()}";
        public bool Answered => !String.IsNullOrWhiteSpace(Answer);
    }
}

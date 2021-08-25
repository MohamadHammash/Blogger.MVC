﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.QAsViewModels
{
    public class CreateQAViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="الرجاء تعبئة الحقل")]
        [Display(Name ="الاسم")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "الرجاء تعبئة الحقل")]
        [Display(Name = "الكنية")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "الرجاء تعبئة الحقل")]
        [Display(Name = "موضوع السؤال")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "الرجاء تعبئة الحقل")]
        [Display(Name = "السؤال")]
        [StringLength(999 , ErrorMessage ="حد الحروف المسموح هو 999 حرف فقط"),MinLength(10 ,ErrorMessage ="السؤال يجب أن يتكون من 10 حروف على الأقل")]
        public string Question { get; set; }
        public string Answer { get; set; }
        [Display(Name = "نشر في ")]
        public DateTime PublishingDate { get; set; }
        public string Initials => $"{FirstName.FirstOrDefault()} {LastName.FirstOrDefault()}";
        public bool Answered => !String.IsNullOrWhiteSpace(Answer);
    }
}

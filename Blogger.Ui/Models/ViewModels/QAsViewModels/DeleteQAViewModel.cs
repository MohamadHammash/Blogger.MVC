using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.QAsViewModels
{
    public class DeleteQAViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        [Display(Name = "نشر في ")]
        public DateTime PublishingDate { get; set; }
        public string Initials => $"{FirstName.FirstOrDefault()} {LastName.FirstOrDefault()}";
        public bool Answered => !String.IsNullOrWhiteSpace(Answer);
    }
}

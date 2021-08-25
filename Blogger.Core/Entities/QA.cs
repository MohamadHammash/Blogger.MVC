using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Entities
{
    public class QA
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime PublishingDate { get; set; }
        public string Initials => $"{FirstName.FirstOrDefault()} {LastName.FirstOrDefault()}";
        public bool Answered => !String.IsNullOrWhiteSpace(Answer);



    }
}

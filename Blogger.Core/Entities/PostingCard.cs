using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Entities
{
     public class PostingCard
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublishingDate { get; set; }

        //nav prop

        


    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Entities
{
   public class VideosList
    {
        public Guid Id { get; set; }
        public string ListName { get; set; }
        public string ImagePath { get; set; }


        // nav Prop
      
        public ICollection<Video> Videos { get; set; }
    }
}

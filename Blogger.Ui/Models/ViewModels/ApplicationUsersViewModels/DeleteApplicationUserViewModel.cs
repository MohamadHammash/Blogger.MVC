using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.ApplicationUsersViewModels
{
    public class DeleteApplicationUserViewModel
    {
        [Display(Name = "الاسم")]
        public string FirstName { get; set; }
        [Display(Name = "اسم العائلة")]
        public string LastName { get; set; }
        public string Role { get; set; }

        public ICollection<Video> Videos { get; set; }
        public ICollection<PostingCard> PostingCards { get; set; }
        public ICollection<VideosList> VideosLists { get; set; }
    }
}

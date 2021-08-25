using Blogger.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Ui.Models.ViewModels.ApplicationUsersViewModels
{
    public class DetailsApplicationUserViewModel
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
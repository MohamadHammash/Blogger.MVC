using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Blogger.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public ICollection<Video> Videos { get; set; }
        public ICollection<PostingCard> PostingCards { get; set; }
        public ICollection<VideosList> VideosLists { get; set; }
    }
}
using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.VideosListsViewModels
{
    public class DeleteVideosListViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "اسم القائمة")]
        public string ListName { get; set; }
        [Display(Name = "الصورة")]
        public string ImagePath { get; set; }

        // nav Prop
        
        public ICollection<Video> Videos { get; set; }
    }
}

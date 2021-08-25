using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Ui.Models.ViewModels.VideosListsViewModels
{
    public class ListVideosListsViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "اسم القائمة")]
        public string ListName { get; set; }


        public string ImagePath { get; set; }

        // nav Prop

        public ICollection<Video> Videos { get; set; }
    }
}
using Microsoft.AspNetCore.Http;
using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Ui.Models.ViewModels.VideosListsViewModels
{
    public class CreateVideosListViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "الرجاء كتابة اسم القائمة")]
        [Display(Name = "اسم القائمة")]
        public string ListName { get; set; }
        [Required(ErrorMessage ="الرجاء تحميل صورة")]
        [Display(Name = "الصورة")]
        public IFormFile  Photo { get; set; }


        // nav Prop
        
        public ICollection<Video> Videos { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blogger.Ui.Services
{
    public interface ISelectVideosListId
    {
        Task<IEnumerable<SelectListItem>> GetVideosListIdAsync();
    }
}
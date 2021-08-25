using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();

        string GetRole(ApplicationUser user);

        Task<ApplicationUser> GetUserByIdAsync(string id);

    
        void Update(ApplicationUser user);

        void Remove(ApplicationUser user);

        public bool Any(string id);

        Task ChangeRoleAsync(ApplicationUser user);
       
    }
}

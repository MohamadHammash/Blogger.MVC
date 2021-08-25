using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Blogger.Core.Entities;
using Blogger.Core.Repositories;
using Blogger.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> userManager;

        public UsersRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;

        }
        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
           
            return await db.Users.FindAsync(id);
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
        {
            return await db.Users.ToListAsync();
        }
        public string GetRole(ApplicationUser user)
        {
            var sb = new StringBuilder();
            var roles = userManager.GetRolesAsync(user).Result.ToList();

            foreach (var item in roles)
            {
                sb.AppendLine(item);
            }
            var rolesName = sb.ToString();
            return rolesName;
        }
        public void Update(ApplicationUser user)
        {
            db.Update(user);
        }
        public void Remove(ApplicationUser user)
        {
            db.Remove(user);
        }

        public bool Any(string id)
        {
            return db.Users.Any(u => u.Id == id);
        }

        //ToDo: Implement Later
        public Task ChangeRoleAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}

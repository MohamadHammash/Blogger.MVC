using Microsoft.AspNetCore.Identity;
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
    public class UoW : IUoW
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> userManager;
        public IPostingCardsRepository PostingCardsRepository { get; set; }
        public IVideosListsRepository VideosListsRepository { get; set; }
        public IVideosRepository VideosRepository { get; set; }
        public IUsersRepository UsersRepository { get; set; }
        public IQAsRepository QAsRepository { get; set; }

        public UoW(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
            PostingCardsRepository = new PostingCardsRepository(this.db);
            VideosListsRepository = new VideosListsRepository(this.db);
            VideosRepository = new VideosRepository(this.db);
            QAsRepository = new QAsRepository(this.db);

        }
        public async Task CompleteAsync() => await db.SaveChangesAsync();
        public async Task<bool> SaveAsync() => (await db.SaveChangesAsync()) >= 0;
    }
}

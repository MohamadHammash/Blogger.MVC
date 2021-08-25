using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogger.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideosList> VideosLists { get; set; }
        public DbSet<PostingCard> PostingCards { get; set; }
        public DbSet<QA> QAs { get; set; }

       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}

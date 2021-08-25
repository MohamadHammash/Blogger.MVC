﻿using Microsoft.EntityFrameworkCore;
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
   public class VideosRepository: IVideosRepository
    {
        private readonly ApplicationDbContext db;
        public VideosRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(Video added)
        {
            await db.AddAsync(added);
        }

        public bool Any(Guid id)
        {
            return db.Videos.Any(v => v.Id == id);
        }

        public async Task<IEnumerable<Video>> GetAllVideosAsync()
        {
           return await db.Videos
                .Include(v=>v.VideosList)
                .OrderByDescending(v=>v.PublishingDate)
                .ToListAsync();
        }

        public async Task<Video> GetVideoByIdAsync(Guid id)
        {
          return  await db.Videos
                .Include(v => v.VideosList)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public void Remove(Video video)
        {
            db.Videos.Remove(video);
        }

        public void Update(Video video)
        {
            db.Videos.Update(video);
        }
    }
}

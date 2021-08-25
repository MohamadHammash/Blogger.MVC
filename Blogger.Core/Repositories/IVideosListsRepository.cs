﻿using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Repositories
{
    public interface IVideosListsRepository
    {
        Task AddAsync(VideosList added);
        Task<IEnumerable<VideosList>> GetAllVideosListsAsync();

        Task<VideosList> GetVideosListByIdAsync(Guid id);

        void Update(VideosList videos);

        void Remove(VideosList videos);

        public bool Any(Guid id);
    }
}

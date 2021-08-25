using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Repositories
{
   public interface IVideosRepository
    {
        Task AddAsync(Video added);
        Task<IEnumerable<Video>> GetAllVideosAsync();

        Task<Video> GetVideoByIdAsync(Guid id);

        void Update(Video video);

        void Remove(Video video);


        public bool Any(Guid id);

       
    }
}

using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Repositories
{
    public interface IPostingCardsRepository
    {
        Task AddAsync(PostingCard added);
        Task<IEnumerable<PostingCard>> GetAllPostingCardsAsync();

        Task<PostingCard> GetPostingCardByIdAsync(Guid id);

        void Update(PostingCard card);

        void Remove(PostingCard card);

        public bool Any(Guid id);
    }
}

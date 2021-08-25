using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Repositories
{
    public interface IUoW
    {
        public IPostingCardsRepository PostingCardsRepository { get; set; }
        public IVideosListsRepository VideosListsRepository { get; set; }
        public IVideosRepository VideosRepository { get; set; }
        public IUsersRepository UsersRepository { get; set; }
        public IQAsRepository QAsRepository { get; set; }

        Task<bool> SaveAsync();
        Task CompleteAsync();
    }
}

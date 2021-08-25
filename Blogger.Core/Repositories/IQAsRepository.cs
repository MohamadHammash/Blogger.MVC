using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Core.Repositories
{
    public interface IQAsRepository
    {
        Task AddAsync(QA added);
        Task<IEnumerable<QA>> GetAllQAsAsync();

        Task<QA> GetQAByIdAsync(Guid id);

        void Update(QA qA);

        void Remove(QA qA);


        public bool Any(Guid id);
    }
}

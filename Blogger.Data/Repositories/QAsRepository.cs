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
    public class QAsRepository : IQAsRepository
    {
        private readonly ApplicationDbContext db;


        public QAsRepository(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task AddAsync(QA added)
        {
            await db.QAs.AddAsync(added);
        }

        public bool Any(Guid id)
        {
            return db.QAs.Any(q => q.Id == id);
        }

        public async Task<IEnumerable<QA>> GetAllQAsAsync()
        {
          return  await db.QAs.OrderByDescending(q=>q.PublishingDate).ToListAsync();
        }

        public async Task<QA> GetQAByIdAsync(Guid id)
        {
            return await db.QAs.FindAsync(id);
        }

        public void Remove(QA qA)
        {
            db.QAs.Remove(qA);
        }

        public void Update(QA qA)
        {
            db.QAs.Update(qA);
        }
    }
}

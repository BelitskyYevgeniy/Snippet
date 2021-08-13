using Microsoft.EntityFrameworkCore;
using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class LanguageRepository: GenericRepository<LanguageEntity>, ILanguageRepositoryAsync
    {
        public LanguageRepository(RepositoryContext db): base(db)
        {

        }

        public async Task<IReadOnlyCollection<LanguageEntity>> GetTopAsync(int count = int.MaxValue, CancellationToken ct = default)
        {
            count = count < 1 ? int.MaxValue : count;
            return await _dbContext.Languages.AsNoTracking()
                .Include(e => e.Posts)
                .Select(e => new
                {
                    Id = e.Id,
                    Name = e.Name,
                    Count = e.Posts.Count
                })
                .OrderBy(obj => obj.Count)
                .Take(count)
                .Select(obj => new LanguageEntity 
                {
                    Id = obj.Id,
                    Name = obj.Name
                }).ToListAsync(ct);
        }

        public override Task<bool> ValidateEntity(LanguageEntity entity, CancellationToken ct = default)
        {
            return Task.FromResult(!(entity == null || entity.Name == null || entity.Name.Length < 1));
        }
    }
}

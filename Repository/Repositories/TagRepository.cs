using Microsoft.EntityFrameworkCore;
using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Repositories
{
    public class TagRepository : GenericRepository<TagEntity>, ITagRepositoryAsync
    {
        public TagRepository(RepositoryContext db) : base(db) { }

        private void ProcessUpdateTagsRequest(IEnumerable<PostTagEntity> currentItems, IEnumerable<PostTagEntity> newItems, out IEnumerable<PostTagEntity> removedPostTags, out IEnumerable<PostTagEntity> addedPostTags)
        {
            var shouldNotCurrentItemsExcept = currentItems == null || currentItems.Count() == 0;
            var shouldNotNewItemsExcept = newItems == null || newItems.Count() == 0;
            if (shouldNotNewItemsExcept)
            {
                addedPostTags = new List<PostTagEntity>();
                removedPostTags = shouldNotCurrentItemsExcept ? new List<PostTagEntity>() : currentItems;
            }
            else
            {
                if (shouldNotCurrentItemsExcept)
                {
                    addedPostTags = newItems;
                    removedPostTags = new List<PostTagEntity>();
                }
                else
                {
                    addedPostTags = newItems.Except(currentItems).ToList();
                    removedPostTags = currentItems.Except(newItems).ToList();
                }
            }
        }
        public async Task UpdateTagsAsync(IEnumerable<PostTagEntity> currentItems, IEnumerable<PostTagEntity> newItems, CancellationToken ct = default)
        {
            IEnumerable<PostTagEntity> removedPostTags;
            IEnumerable<PostTagEntity> addedPostTags;
            ProcessUpdateTagsRequest(currentItems, newItems, out removedPostTags, out addedPostTags);
            foreach (var postTag in removedPostTags)
            {
                if(postTag == null)
                {
                    continue;
                }
                var query = _dbContext.PostTags.Include(pt => pt.Tag).Where(pt => pt.TagId == postTag.TagId).AsNoTracking();
                var shouldDeleteTag = query.Count() == 1;
                var tag = postTag.Tag;
                _dbContext.PostTags.Remove(postTag);
                if (shouldDeleteTag)
                {
                    _dbContext.Tags.Remove(tag);
                }
            }
            
            await _dbContext.PostTags.AddRangeAsync(addedPostTags, ct);
            await _dbContext.SaveChangesAsync(ct);
        }


        public async Task<IReadOnlyCollection<TagEntity>> GetTopAsync(int count = int.MaxValue, CancellationToken ct = default)
        {
            count = count < 1 ? int.MaxValue : count;
            return await _dbContext.Tags.AsNoTracking()
                .Include(e => e.PostTags)
                .Select(e => new
                {
                    Id = e.Id,
                    Name = e.Name,
                    Count = e.PostTags.Count
                })
                .OrderBy(obj => obj.Count)
                .Take(count)
                .Select(obj => new TagEntity
                {
                    Id = obj.Id,
                    Name = obj.Name
                }).ToListAsync(ct);

        }

        public override Task<bool> ValidateEntity(TagEntity entity, CancellationToken ct = default)
        {
            return Task.FromResult(!(entity == null || entity.Name == null || entity.Name.Length < 1));
        }
    }

}

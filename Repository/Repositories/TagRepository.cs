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
                var query = _dbContext.PostTags.Include(pt => pt.Tag).Where(pt => pt.TagId == postTag.TagId);
                var shouldDeleteTag = query.Count() == 1;
                var tag = query.Select(pt => pt.Tag).FirstOrDefault();
                postTag.Tag = null;
                postTag.Post = null;
                _dbContext.PostTags.Remove(postTag);
                if (shouldDeleteTag)
                {
                    _dbContext.Tags.Remove(tag);
                }
            }
            
            await _dbContext.PostTags.AddRangeAsync(addedPostTags, ct);
            await _dbContext.SaveChangesAsync(ct);
        }
    }

}

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Threading;
using Services.Interfaces.Providers;
using Snippet.Data.Interfaces.Generic;
using Snippet.Data.Entities;
using Services.Models;
using Snippet.Data.Interfaces;
using Snippet.Data.Interfaces.Repositories;
using System.Linq;
using System.Linq.Expressions;
using System;
using Services.Models.RequestModels;

namespace Services.Providers
{
    public class CommentProvider : ICommentProvider
    {

        private readonly ICommentRepositoryAsync _commentRepository;
        private readonly IMapper _mapper;
        public CommentProvider(IMapper mapper, ICommentRepositoryAsync commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            return await _commentRepository.DeleteAsync(id, ct);
        }
        public async Task<IReadOnlyCollection<Comment>> GetAllByPostIdAsync(int postId, int skip = 0, int count = 1, CancellationToken ct = default)
        {
            var comments = await _commentRepository.FindAsync(skip, count, new Expression<Func<CommentEntity, bool>>[] { (x) => x.PostId == postId }, comments => comments.OrderBy(comment => comment.CreationDateTime), null, ct);
            return _mapper.Map<IEnumerable<CommentEntity>, IReadOnlyCollection<Comment>>(comments);
        }
        public async Task<CommentRequest> CreateAsync(CommentRequest comment, CancellationToken ct = default)
        {
            var entity = _mapper.Map<CommentEntity>(comment);
            entity.CreationDateTime = DateTime.Now;

            entity = await _commentRepository.CreateAsync(entity,ct);
            
            return _mapper.Map<CommentRequest>(entity);
        }
        public async Task<CommentRequest> UpdateAsync(CommentRequest model,int commentId, CancellationToken ct)
        {
            var entity = _mapper.Map<CommentEntity>(model);

            entity.Id = commentId;
            entity.LastUpdateDateTime = DateTime.Now;
            entity = await _commentRepository.UpdateAsync(entity, ct);

            return _mapper.Map<CommentRequest>(entity);
        }
    }
}

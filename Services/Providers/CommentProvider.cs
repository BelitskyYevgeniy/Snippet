using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Threading;
using Services.Interfaces.Providers;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Linq;
using System.Linq.Expressions;
using System;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Services.Interfaces.Services;

namespace Services.Providers
{
    public class CommentProvider : ICommentProvider
    {
        private readonly IPaginationService _paginationService;
        private readonly ICommentRepositoryAsync _commentRepository;
        private readonly IMapper _mapper;
        public CommentProvider(IMapper mapper, ICommentRepositoryAsync commentRepository,IPaginationService paginationService)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _paginationService = paginationService;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            return await _commentRepository.DeleteAsync(id, ct);
        }

        public async Task<IReadOnlyCollection<CommentResponse>> GetAllByPostIdAsync(int postId, int skip = 0, int count = int.MaxValue, CancellationToken ct = default)
        {
            count = _paginationService.ValidateCount(count);
            var comments = await _commentRepository.FindAsync(skip, count, false,
                new Expression<Func<CommentEntity, bool>>[] { (x) => x.PostId == postId }, 
                comments => comments.OrderBy(comment => comment.CreationDateTime), null, ct);
            return _mapper.Map<IEnumerable<CommentEntity>, IReadOnlyCollection<CommentResponse>>(comments);
        }
        public async Task DeleteAllByPostIdAsync(int postId, CancellationToken ct = default)
        {
            var commentResponses = await GetAllByPostIdAsync(postId, 0, ct: ct);
            var comments = _mapper.Map<IReadOnlyCollection<CommentEntity>>(commentResponses);
            await _commentRepository.DeleteRangeAsync(comments, ct);
        }
        public async Task<CommentResponse> CreateAsync(CommentRequest comment, CancellationToken ct = default)
        {
            if (comment == null || comment.FatherCommentId != null)
            {
                var commentFather = await _commentRepository.GetByIdAsync((int)comment.FatherCommentId);
                if (commentFather == null)
                {
                    return null;
                }
            }
            var entity = _mapper.Map<CommentEntity>(comment);
            entity.CreationDateTime = DateTime.Now;

            entity = await _commentRepository.CreateAsync(entity,ct);
            
            return _mapper.Map<CommentResponse>(entity);
        }
        public async Task<CommentResponse> UpdateAsync(int id, CommentRequest model, CancellationToken ct = default)
        {
            if(model == null)
            {
                return null;
            }
            var entity = _mapper.Map<CommentEntity>(model);

            entity.Id = id;
            entity.LastUpdateDateTime = DateTime.Now;
            entity = await _commentRepository.UpdateAsync(entity, ct);

            return _mapper.Map<CommentResponse>(entity);
        }
    }
}

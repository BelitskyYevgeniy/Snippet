using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Threading;
using Services.Interfaces.Providers;
using Snippet.Data.Interfaces.Generic;
using Snippet.Data.Entities;
using Services.Models;
using Snippet.Data.Interfaces;

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
        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await _commentRepository.DeleteAsync(id, ct);
        }
        public async Task<IReadOnlyCollection<Comment>> GetAllByPostIdAsync(int postId, CancellationToken ct)
        {
            var comments = await _commentRepository.FindAsync((x) => x.PostId == postId,ct);
            return _mapper.Map<IEnumerable<CommentEntity>, IReadOnlyCollection<Comment>>(comments);
        }
        public async Task<Comment> MakeAsync(Comment comment, CancellationToken ct)
        {
            var entity = _mapper.Map<CommentEntity>(comment);

            entity = await _commentRepository.CreateAsync(entity,ct);
            
            return _mapper.Map<Comment>(entity);
        }
        public async Task<Comment> UpdateAsync(Comment model, CancellationToken ct)
        {
            model.LastUpdateDateTime = System.DateTime.Now;

            var entity = _mapper.Map<CommentEntity>(model);

            entity = await _commentRepository.UpdateAsync(entity, ct);


            return _mapper.Map<Comment>(entity);
        }
    }
}

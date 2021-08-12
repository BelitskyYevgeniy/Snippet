using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using Snippet.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        private readonly ICommentProvider _commentProvider;

        public CommentService(ICommentProvider commentProvider, IMapper mapper, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
            _commentProvider = commentProvider;
        }

        public async Task<CommentResponse> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var entity = await _commentProvider.GetByIdAsync(id, ct: ct).ConfigureAwait(false);
            return _mapper.Map<CommentResponse>(entity);
        }

        [Authorize]
        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var user = await _authenticationService.GetUserAsync(ct).ConfigureAwait(false);
            var comment = await _commentProvider.GetByIdAsync(id, ct).ConfigureAwait(false);
            if (comment == null || comment.UserId != user.Id)
            {
                return false;
            }
            return await _commentProvider.DeleteAsync(comment, ct).ConfigureAwait(false);
        }

        [Authorize]
        public async Task<CommentResponse> CreateAsync(CommentRequest comment, CancellationToken ct = default)
        {
            if(comment == null)
            {
                return null;
            }
            comment.UserId = (await _authenticationService.GetUserAsync(ct).ConfigureAwait(false)).Id;
            return await _commentProvider.CreateAsync(comment, ct).ConfigureAwait(false);
        }

        [Authorize]
        public async Task<CommentResponse> UpdateAsync(int id, CommentRequest model, CancellationToken ct = default)
        {
            if (model == null)
            {
                return null;
            }
            var entity = _mapper.Map<CommentEntity>(model);
            entity.Id = id;
            var userId = (await _authenticationService.GetUserAsync(ct).ConfigureAwait(false)).Id;
            if(entity.UserId != userId)
            {
                return null;
            }
            return await _commentProvider.UpdateAsync(entity, ct).ConfigureAwait(false);
        }
    }
}

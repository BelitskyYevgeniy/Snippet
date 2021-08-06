using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Providers
{
    public class LikeProvider : ILikeProvider
    {
        private readonly IMapper _mapper;

        private readonly ILikeRepositoryAsync _likeRepository;
        public LikeProvider(IMapper mapper, ILikeRepositoryAsync likeRepository)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
        }

        /*public async Task<int> GetAllByPostAsync(int postId, CancellationToken ct)
        {
            var entities = await _likeRepository.FindAsync((x) => x.PostId == postId, ct);
            return _mapper.Map<IReadOnlyCollection<Like>>(entities).Count;

        }*/

        public Task<int> GetCountAsync(int postId, CancellationToken ct = default)
        {
            return _likeRepository.GetCount(ct);
        }

        public async Task<Like> CreateAsync(Like like, CancellationToken ct = default)
        {
            var entity = _mapper.Map<Like, LikeEntity>(like);
            var foundLike = (await _likeRepository.FindAsync(filter: new Expression<Func<LikeEntity, bool>>[] { (x) => x.UserId == like.UserId && x.PostId == like.postId }, ct: ct)).FirstOrDefault();
            if (foundLike == null)
            {
                await RemoveAsync(like, ct);
            }
            return null;
        }

        public async Task<bool> RemoveAsync(Like like, CancellationToken ct = default)
        {
       
            return await _likeRepository.DeleteAsync(like.Id, ct);
    
        }
    }
}

using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models.RequestModels;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
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

        public Task<IReadOnlyCollection<LikeEntity>> GetAllByPostAsync(int postId, CancellationToken ct = default)
        {
            return _likeRepository.FindAsync(skip: 0, count: int.MaxValue,
                filter: new List<Expression<Func<LikeEntity, bool>>>() { (x) => x.PostId == postId }, 
                ct: ct);
        }

        public async Task DeleteLikesOfPostAsync(int postId, CancellationToken ct = default)
        {
            var likes = await GetAllByPostAsync(postId, ct);
            if (likes.Count != 0)
            {
                await _likeRepository.DeleteRangeAsync(likes);
            }
        }
        public Task<int> GetCountAsync(int postId, CancellationToken ct = default)
        {
            return _likeRepository.GetCount(ct);
        }

        public async Task<LikeRequest> CreateAsync(LikeRequest like, CancellationToken ct = default)
        {
            if(like == null)
            {
                return null;
            }
            var entity = _mapper.Map<LikeRequest, LikeEntity>(like);
            var foundLike = (await _likeRepository.FindAsync(filter: new Expression<Func<LikeEntity, bool>>[] { (x) => x.UserId == like.UserId && x.PostId == like.PostId }, ct: ct)).FirstOrDefault();
            if (foundLike != null)
            {
               var res = await _likeRepository.DeleteAsync(foundLike, ct);
               return null;
            }
            entity = await _likeRepository.CreateAsync(entity, ct);
            return like;
        }
    }
}

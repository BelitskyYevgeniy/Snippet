using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Providers
{
    public class LikeProvider : ILikeProvider
    {
        private readonly IMapper _mapper;

        private readonly IGenericRepositoryAsync<LikeEntity> _likeRepository;
        public LikeProvider(IMapper mapper,IGenericRepositoryAsync<LikeEntity> likeRepository)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
        }

        public async Task<int> GetAllByPostAsync(int postId, CancellationToken ct)
        {
            var entities = await _likeRepository.FindAsync((x) => x.PostId == postId, ct);
            return _mapper.Map<IReadOnlyCollection<Like>>(entities).Count;

        }

        public async Task<Like> Like(Like like, CancellationToken ct)
        {
            var entity = _mapper.Map<Like, LikeEntity>(like);
            var liked = await _likeRepository.FindAsync((x) => x.UserId == like.UserId && x.PostId == like.postId, ct);
            if (liked != null)
            {
                 await  RemoveLike(liked.First().Id, ct);
            }

            entity = await _likeRepository.CreateAsync(entity, ct);
            return _mapper.Map<LikeEntity, Like>(entity);
        }

        public async Task<bool> RemoveLike(int likeId, CancellationToken ct)
        {
            return await _likeRepository.DeleteAsync(likeId, ct);
        }
    }
}

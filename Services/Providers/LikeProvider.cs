using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces;
using Snippet.Data.Interfaces.Generic;
using Snippet.Data.Interfaces.Repositories;
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
            var foundLike = (await _likeRepository.FindAsync(filter: (x) => x.UserId == like.UserId && x.PostId == like.postId, ct: ct)).FirstOrDefault();
            if (foundLike == null)
            {
                entity = await _likeRepository.CreateAsync(entity, ct);
                return _mapper.Map<LikeEntity, Like>(entity);
            }
            return null;
        }

        public async Task<bool> RemoveAsync(Like like, CancellationToken ct = default)
        {
            var entity = _mapper.Map<Like, LikeEntity>(like);
            var foundLike = (await _likeRepository.FindAsync(filter: (x) => x.UserId == like.UserId && x.PostId == like.postId, ct: ct)).FirstOrDefault();
            if(foundLike != null)
            {
                return await _likeRepository.DeleteAsync(foundLike.Id, ct);
            }
            return false;
        }
    }
}

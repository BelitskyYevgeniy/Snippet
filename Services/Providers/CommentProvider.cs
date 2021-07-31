﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Threading;
using Services.Interfaces.Providers;
using Snippet.Data.Interfaces.Generic;
using Snippet.Data.Entities;
using Services.Models;

namespace Services.Providers
{
    public class CommentProvider : ICommentProvider
    {

        private readonly IGenericRepositoryAsync<CommentEntity> _genericRepository;
        private readonly IMapper _mapper;
        public CommentProvider(IMapper mapper,IGenericRepositoryAsync<CommentEntity> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<bool> DeleteAsync(int id, CancellationToken ct)
        {
            return await _genericRepository.DeleteAsync(id, ct);
        }
        public async Task<IReadOnlyCollection<Comment>> GetAllByPostIdAsync(int postId, CancellationToken ct)
        {
            var comments = await _genericRepository.FindAsync((x) => x.Id == postId,ct);// change this method
            return _mapper.Map<IEnumerable<CommentEntity>, IReadOnlyCollection<Comment>>(comments);
        }
        public async Task<Comment> MakeAsync(Comment post, CancellationToken ct)
        {
            var entity = _mapper.Map<CommentEntity>(post);

            entity = await _genericRepository.CreateAsync(entity,ct);
            

            return _mapper.Map<Comment>(entity);
        }
        public async Task<Comment> UpdateAsync(Comment model, CancellationToken ct)
        {
            var entity = _mapper.Map<CommentEntity>(model);

            entity = await _genericRepository.UpdateAsync(entity, ct);


            return _mapper.Map<Comment>(entity);
        }
    }
}

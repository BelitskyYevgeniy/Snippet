using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
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
    public class UserProvider : IUserProvider
    {
        private readonly IMapper _mapper;
        private readonly IUserRepositoryAsync _userRepository;

        public UserProvider(IMapper mapper, IUserRepositoryAsync userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<UserResponse> GetByIdAsync(int id, CancellationToken ct)
        {
            var model = await _userRepository.GetByIdAsync(id, ct: ct);

            return _mapper.Map<UserEntity, UserResponse>(model);
        }

        public async Task<UserResponse> CreateAsync(UserRequest model, CancellationToken ct = default)
        {
            var entity = _mapper.Map<UserEntity>(model);
            var createdEntity = await _userRepository.CreateAsync(entity, ct);
            return _mapper.Map<UserResponse>(createdEntity);
        }
        public async Task<UserResponse> GetByAuthIdAsync(string userAuthId, CancellationToken ct = default)
        {
            var entity = (await _userRepository.FindAsync(
                filter: new List<Expression<Func<UserEntity, bool>>>() { e => e.AuthId == userAuthId },
                ct: ct)
                .ConfigureAwait(false))
                .FirstOrDefault();
            return _mapper.Map<UserResponse>(entity);
        }

    }
}

using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
using Services.Models.ResponseModels;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IMapper _mapper;
        private readonly IUserRepositoryAsync _userRepository;

        public UserProvider(IMapper mapper,IUserRepositoryAsync userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<UserResponse> GetByIdAsync(int id, CancellationToken ct)
        {
            var model = await _userRepository.GetByIdAsync(id, ct: ct);

            return _mapper.Map<UserEntity, UserResponse>(model);
        }
    }
}

using AutoMapper;
using Services.Interfaces.Providers;
using Services.Models;
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
        public async Task<User> GetById(int id, CancellationToken ct)
        {
            var model = await _userRepository.GetByIdAsync(id, ct);

            return _mapper.Map<UserEntity, User>(model);
        }
    }
}

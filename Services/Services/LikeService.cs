using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces.Providers;
using Services.Interfaces.Services;
using Services.Models.RequestModels;
using Snippet.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services
{
    public class LikeService : ILikeService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILikeProvider _likeProvider;

        public LikeService(IAuthenticationService authenticationService, ILikeProvider likeProvider)
        {
            _authenticationService = authenticationService;
            _likeProvider = likeProvider;
        }

        [Authorize]
        public async Task<bool> CreateAsync(LikeRequest like, CancellationToken ct = default)
        {
            if(like == null)
            {
                return false;
            }
            like.UserId = (await _authenticationService.GetUserAsync(ct).ConfigureAwait(false)).Id;
            return await _likeProvider.CreateAsync(like, ct).ConfigureAwait(false);
        }
    }
}

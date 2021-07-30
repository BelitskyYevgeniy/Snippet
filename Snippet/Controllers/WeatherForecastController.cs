using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Snippet.Data.Interfaces;
using System.Threading.Tasks;
using Snippet.Data.Entities;
using System.Threading;

namespace Snippet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public IUserRepositoryAsync _userRepository;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IUserRepositoryAsync userRepository, ILogger<WeatherForecastController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet]
        public Task<UserEntity> Get(CancellationToken ct)
        {
            return _userRepository.CreateAsync(new Data.Entities.UserEntity { Name = "admin" }, ct);
            
        }
    }
}

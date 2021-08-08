using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Models;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController:ControllerBase
    {
        private readonly ILanguageProvider _languageProvider;

        public LanguageController(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
        }

        [HttpGet]
        public Task<IReadOnlyCollection<LanguageResponse>> GetRaiting(CancellationToken ct)
        {
            return _languageProvider.GetRating(ct);
        }

        [HttpPost]
        public Task<LanguageResponse> Create(LanguageRequest language, CancellationToken ct)
        {
            return _languageProvider.CreateAsync(language, ct);
        }

        [HttpDelete]
        public Task<bool> Delete(int id, CancellationToken ct)
        {
            return  _languageProvider.DeleteAsync(id, ct);
        }

        //[HttpPut]
        //public Task<Language> Update(Language language, CancellationToken ct)
        //{
        //    return _languageProvider.UpdateAsync(language, ct);
        //}
    }
}

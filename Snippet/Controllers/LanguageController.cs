using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    public class LanguageController:ControllerBase
    {
        private readonly ILanguageProvider _languageProvider;

        public LanguageController(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
        }

        [HttpPost]
        public Task<Language> Create(Language language,CancellationToken ct)
        {
            return _languageProvider.CreateAsync(language, ct);
        }

        [HttpDelete]
        public Task<bool> Delete(int id,CancellationToken ct)
        {
            return _languageProvider.DeleteAsync(id, ct);
        }

        [HttpPut]
        public Task<Language> Update(Language language,CancellationToken ct)
        {
            return _languageProvider.UpdateAsync(language, ct);
        }
    }
}

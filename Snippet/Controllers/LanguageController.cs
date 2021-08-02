using Services.Interfaces.Providers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    public class LanguageController
    {
        private readonly ILanguageProvider _languageProvider;

        public LanguageController(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
        }

        public Task<Language> Create(Language language,CancellationToken ct)
        {
            return _languageProvider.MakeAsync(language, ct);
        }

        public Task<bool> Delete(int id,CancellationToken ct)
        {
            return _languageProvider.DeleteAsync(id, ct);
        }

        public Task<Language> Update(Language language,CancellationToken ct)
        {
            return _languageProvider.UpdateAsync(language, ct);
        }
    }
}

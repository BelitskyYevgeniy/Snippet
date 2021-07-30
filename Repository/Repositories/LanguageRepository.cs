using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snippet.Data.Repositories
{
    class LanguageRepository: GenericRepository<LanguageEntity>, ILanguageRepositoryAsync
    {
        public LanguageRepository(RepositoryContext db): base(db)
        {

        }
    }
}

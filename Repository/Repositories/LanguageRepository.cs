﻿using Snippet.Data.Context;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces;

namespace Snippet.Data.Repositories
{
    class LanguageRepository: GenericRepository<LanguageEntity>, ILanguageRepositoryAsync
    {
        public LanguageRepository(RepositoryContext db): base(db)
        {

        }
    }
}

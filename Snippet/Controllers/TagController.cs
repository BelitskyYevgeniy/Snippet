using AutoMapper;
using Services.Models;
using Snippet.BLL.Interfaces.Providers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    public class TagController
    {
        private readonly IMapper _mapper;
        private readonly ITagProvider _tagProvider;

        public TagController(IMapper mapper,ITagProvider tagProvider)
        {
            _mapper = mapper;
            _tagProvider = tagProvider;
        }

        public Task<bool> Delete(int id,CancellationToken ct)
        {
            return _tagProvider.DeleteAsync(id, ct);
        }

        public Task<IReadOnlyCollection<Tag>> Create(IReadOnlyCollection<Tag> tags,CancellationToken ct)
        {
            return _tagProvider.MakeAsync(tags, ct);
        }

        public Task<Tag> Update(Tag tag,CancellationToken ct)
        {
            return _tagProvider.UpdateAsync(tag, ct);
        }
    }
}

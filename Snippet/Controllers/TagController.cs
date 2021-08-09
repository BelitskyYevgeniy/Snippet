using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Models.ResponseModels;
using Snippet.BLL.Interfaces.Providers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController
    {
        private readonly IMapper _mapper;
        private readonly ITagProvider _tagProvider;

        public TagController(IMapper mapper, ITagProvider tagProvider)
        {
            _mapper = mapper;
            _tagProvider = tagProvider;
        }

        [HttpGet]
        public Task<IReadOnlyCollection<TagResponse>> GetTop(int count = int.MaxValue, CancellationToken ct = default)
        {
            return _tagProvider.GetTopAsync(count, ct);
        }


        /*

        [HttpDelete]
        [Authorize]
        public Task<bool> Delete(int id,CancellationToken ct)
        {
            return _tagProvider.DeleteAsync(id, ct);
        }

        [HttpPost]
        [Authorize]
        public Task<IReadOnlyCollection<Tag>> Create(IReadOnlyCollection<Tag> tags,CancellationToken ct)
        {
            return _tagProvider.MakeAsync(tags, ct);
        }

        [HttpPut]
        [Authorize]
        public Task<Tag> Update(Tag tag,CancellationToken ct)
        {
            return _tagProvider.UpdateAsync(tag, ct);
        }*/
    }
}

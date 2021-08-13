using Microsoft.AspNetCore.Http;
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
        private readonly ITagProvider _tagProvider;

        public TagController(ITagProvider tagProvider)
        {
            _tagProvider = tagProvider;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<TagResponse>))]
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

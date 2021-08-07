using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Models;
using Services.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController:ControllerBase
    {
        private readonly ICommentProvider _commentProvider;

        public CommentController(ICommentProvider commentProvider)
        {
            _commentProvider = commentProvider;
        }
        [HttpGet]
        public Task<IReadOnlyCollection<Comment>> GetAllByPostId(int postId, int skip = 0, int count = 1, CancellationToken ct = default)
        {
            return _commentProvider.GetAllByPostIdAsync(skip, count, postId, ct);
        }

        [HttpPost]
       // [Authorize]
        public Task<CommentRequest> Create(CommentRequest comment,CancellationToken ct)
        {
            return _commentProvider.CreateAsync(comment, ct);
        }

        [HttpDelete]
       // [Authorize]
        public Task<bool> Delete(int id,CancellationToken ct)
        {
            return _commentProvider.DeleteAsync(id, ct);
        }
        [HttpPut]
       // [Authorize]
        public Task<CommentRequest> Update(CommentRequest comment,int commentId,CancellationToken ct)
        {
            return _commentProvider.UpdateAsync(comment,commentId, ct);
        }
    }
}

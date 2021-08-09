﻿using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Models.RequestModels;
using Services.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentProvider _commentProvider;

        public CommentController(ICommentProvider commentProvider)
        {
            _commentProvider = commentProvider;
        }
        [HttpGet]
        public Task<IReadOnlyCollection<CommentResponse>> GetAllByPostId(int postId, int skip = 0, int count = int.MaxValue, CancellationToken ct = default)
        {
            return _commentProvider.GetAllByPostIdAsync(postId, skip, count, ct);
        }

        [HttpPost]
       // [Authorize]
        public Task<CommentResponse> Create(CommentRequest comment, CancellationToken ct = default)
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
        public Task<CommentResponse> Update(int commentId, CommentRequest comment, CancellationToken ct = default)
        {
            return _commentProvider.UpdateAsync(comment,commentId, ct);
        }
    }
}

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Providers;
using Services.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.WebAPI.Controllers
{
    public class CommentController:ControllerBase
    {
        private readonly ICommentProvider _commentProvider;

        public CommentController(ICommentProvider commentProvider)
        {
            _commentProvider = commentProvider;
        }
        [HttpGet]
        public Task<IReadOnlyCollection<Comment>> GetAllByPostId(int postId,CancellationToken ct)
        {
            return _commentProvider.GetAllByPostIdAsync(postId,ct);
        }

        [HttpPost]
        [Authorize]
        public Task<Comment> Create(Comment comment,CancellationToken ct)
        {
            return _commentProvider.MakeAsync(comment, ct);
        }

        [HttpDelete]
        [Authorize]
        public Task<bool> Delete(int id,CancellationToken ct)
        {
            return _commentProvider.DeleteAsync(id, ct);
        }
        [HttpPut]
        [Authorize]
        public Task<Comment> Update(Comment comment,CancellationToken ct)
        {
            
            return _commentProvider.UpdateAsync(comment, ct);
        }
        [HttpPost]
        [Authorize]
        public Task<Comment> ToAnswer(Comment comment,int FatherCommentId,CancellationToken ct)
        {
            comment.FatherCommentId = FatherCommentId;
            return _commentProvider.MakeAsync(comment, ct);
        }
 
    }
}
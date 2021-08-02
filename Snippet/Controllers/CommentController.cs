using Microsoft.AspNetCore.Mvc;
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
        public Task<Comment> Create(Comment comment,CancellationToken ct)
        {
            return _commentProvider.MakeAsync(comment, ct);
        }

        [HttpDelete]
        public Task<bool> Delete(int id,CancellationToken ct)
        {
            return _commentProvider.DeleteAsync(id, ct);
        }

        public Task<Comment> Update(Comment comment,CancellationToken ct)
        {
            
            return _commentProvider.UpdateAsync(comment, ct);
        }

        public Task<Comment> ToAnswer(Comment comment,int FatherCommentId,CancellationToken ct)
        {
            comment.FatherCommentId = FatherCommentId;
            return _commentProvider.MakeAsync(comment, ct);
        }
 
    }
}

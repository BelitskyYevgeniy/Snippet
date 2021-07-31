﻿using Snippet.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snippet.Data.Entities
{
    public class CommentEntity : BaseEntity
    {
        [Required]
        public int PostId { get; set; }
        public PostEntity Post { get; set; }


        public int? UserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;
        [Required]
        public DateTime CreationDateTime { get; set; }
        [Required]
        public DateTime LastUpdateDateTime { get; set; }

        public int? FatherCommentId{ get;set;}
        public CommentEntity FatherComment { get; set; }
    }
}

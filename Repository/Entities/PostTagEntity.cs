using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Snippet.Data.Entities
{
    public class PostTagEntity : IEquatable<PostTagEntity>
    {

        [Required]
        public int PostId { get; set; }
        public PostEntity Post { get; set; }

        [Required]
        public int TagId { get; set; }
        public TagEntity Tag { get; set; }


        public bool Equals([AllowNull] PostTagEntity other)
        {
            if (other is null)
                return false;
            return PostId == other.PostId && TagId == other.TagId;
        }

        public override bool Equals(object obj) => Equals(obj as PostTagEntity);
        public override int GetHashCode() => (PostId, TagId).GetHashCode();
    }
}

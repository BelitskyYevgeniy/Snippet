using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Services.Models.RequestModels
{
    public class TagRequest: IEquatable<TagRequest>
    {
        [Required]
        public string Name { get; set; }

        public bool Equals([AllowNull] TagRequest other)
        {
            if (other is null)
            {
                return false;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

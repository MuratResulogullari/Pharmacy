using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Core.Entities.Bases
{
    public class BaseEntity : BaseEntity<int>
    {
    }

    public class BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        [Required]
        public int LanguageId { get; set; } = default!;

        [Required]
        public bool Enable { get; set; } = true;

        [Required]
        public int SortOrder { get; set; } = default!;

        [Required]
        public int CreatedBy { get; set; } = 1;

        [Required, MaxLength(50)]
        public string CreatedOn { get; set; } = DateTime.UtcNow.ToString()!;

        public int? ModifiedBy { get; set; } = null!;

        [MaxLength(50)]
        public string? ModifiedOn { get; set; } = null!;

        public int? DeletedBy { get; set; } = null!;

        [MaxLength(50)]
        public string? DeletedOn { get; set; } = null!;
    }
}
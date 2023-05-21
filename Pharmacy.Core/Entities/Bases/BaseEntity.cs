using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ushort LanguageId { get; set; } = default!;
        [Required]
        public bool Enable { get; set; } = true;
        [Required]
        public ushort SortOrder { get; set; } = default!;
        [Required]
        public int CreatedBy { get; set; } = 1;
        [Required, DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int? ModifiedBy { get; set; } = null;
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; } = null;
        public int? DeletedBy { get; set; } = null;
        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; } = null;
    }
}

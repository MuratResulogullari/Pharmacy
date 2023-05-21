using Pharmacy.Core.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Users
{
    [Table("Roles")]
    public class Role : BaseEntity<int>
    {
        public string? Name { get; set; }

        public string? NormalizedName { get; set; }

        public string? ConcurrencyStamp { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public override string ToString() => Name ?? string.Empty;
    }
}
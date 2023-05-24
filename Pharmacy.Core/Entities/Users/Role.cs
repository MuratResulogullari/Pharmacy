using Pharmacy.Core.Entities.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Users
{
    [Table("Roles")]
    public class Role : BaseEntity<int>
    {
        [Required,MaxLength(250,ErrorMessage ="str_max250_var")]
        public string Name { get; set; }
        [MaxLength(250, ErrorMessage = "str_max250_var")]
        public string? NormalizedName { get; set; }
        [MaxLength(250, ErrorMessage = "str_max250_var")]
        public string? ConcurrencyStamp { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public override string ToString() => Name ?? string.Empty;
    }
}
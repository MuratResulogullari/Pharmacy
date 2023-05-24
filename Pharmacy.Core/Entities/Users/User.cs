using Microsoft.AspNetCore.Identity;
using Pharmacy.Core.Entities.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Users
{
    [Table("Users")]
    public class User : BaseEntity<int>
    {
        [ProtectedPersonalData, Required, MaxLength(11, ErrorMessage = "str_max11_var")]
        public string TCKN { get; set; }

        [Required, MaxLength(50, ErrorMessage = "str_max50_var")]
        public string Name { get; set; }

        [Required, MaxLength(50, ErrorMessage = "str_max50_var")]
        public string Surname { get; set; }

        [ProtectedPersonalData, Required, MaxLength(50, ErrorMessage = "str_max50_var")]
        public string? UserName { get; set; }

        [MaxLength(50, ErrorMessage = "str_max50_var")]
        public string? NormalizedUserName { get; set; }

        [ProtectedPersonalData, Required, MaxLength(100, ErrorMessage = "str_max100_var"), EmailAddress]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "str_max100_var")]
        public string? NormalizedEmail { get; set; }

        [PersonalData]
        public bool EmailConfirmed { get; set; }

        [Required, MaxLength(250, ErrorMessage = "str_max250_var")]
        public string PasswordHash { get; set; }

        public string? SecurityStamp { get; set; }

        public string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [Required, MaxLength(15, ErrorMessage = "str_max20_var"), Phone]
        public string PhoneNumber { get; set; }

        [PersonalData]
        public bool PhoneNumberConfirmed { get; set; }

        [PersonalData]
        public bool TwoFactorEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public override string ToString() => UserName ?? string.Empty;
    }
}
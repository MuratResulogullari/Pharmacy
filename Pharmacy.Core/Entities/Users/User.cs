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

        public string? NormalizedUserName { get; set; }

        [ProtectedPersonalData, Required, MaxLength(100, ErrorMessage = "str_max100_var"), EmailAddress]
        public string EmailAddress { get; set; }

        public string? NormalizedEmail { get; set; }

        [PersonalData]
        public bool EmailConfirmed { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        public string? SecurityStamp { get; set; }

        public string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        [Required, MaxLength(20, ErrorMessage = "str_max20_var"), Phone]
        public string Phone { get; set; }

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
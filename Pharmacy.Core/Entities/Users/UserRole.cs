using Pharmacy.Core.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Core.Entities.Users
{
    [Table("UserRoles")]
    public class UserRole : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
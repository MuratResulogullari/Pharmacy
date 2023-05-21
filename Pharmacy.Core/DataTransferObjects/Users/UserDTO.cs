using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Core.DataTransferObjects.Users
{
    public class UserDTO : BaseDTO<int>
    {
        [ProtectedPersonalData, Required, MaxLength(11, ErrorMessage = "str_max11_var")]
        public string TCKN { get; set; }

        [Required, MaxLength(50, ErrorMessage = "str_max50_var")]
        public string Name { get; set; }

        [Required, MaxLength(50, ErrorMessage = "str_max50_var")]
        public string Surname { get; set; }

        [ProtectedPersonalData, Required, MaxLength(50, ErrorMessage = "str_max50_var")]
        public string? UserName { get; set; }

        [ProtectedPersonalData, Required, MaxLength(100, ErrorMessage = "str_max100_var"), EmailAddress]
        public string EmailAddress { get; set; }

        [Required, MaxLength(20, ErrorMessage = "str_max20_var"), Phone]
        public string Phone { get; set; }

        [Required, MaxLength(100, ErrorMessage = "str_max100_var")]
        public string Password { get; set; }

        public virtual int[] RoleIds  { get; set; }
    }
}
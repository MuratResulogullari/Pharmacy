using Pharmacy.Core.Entities.Bases;
using Pharmacy.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Core.Entities.Pharmacies
{
    public class Pharmacy : BaseEntity
    {
        [Required, MaxLength(250, ErrorMessage = "str_max250_var")]
        public string Name { get; set; }

        [Required, MaxLength(250, ErrorMessage = "str_max250_var")]
        public string Address { get; set; }

        [Required, Phone, MaxLength(20, ErrorMessage = "str_max20_var")]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress, MaxLength(50, ErrorMessage = "str_max50_var")]
        public string Email { get; set; }

        public EPharmacyStatus Status { get; set; } = EPharmacyStatus.Close!;
    }
}
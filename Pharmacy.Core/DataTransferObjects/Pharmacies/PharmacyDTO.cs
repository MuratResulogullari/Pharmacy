using Pharmacy.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.DataTransferObjects.Pharmacies
{
    public class PharmacyDTO:BaseDTO
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

using FluentValidation;
using Pharmacy.Core.DataTransferObjects.Pharmacies;

namespace Pharmacy.Core.Validators.Pharmacies
{
    public class PharmacyDTOValidator : AbstractValidator<PharmacyDTO>
    {
        public PharmacyDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty.")
                               .MaximumLength(250).WithMessage("{PropertyName} should be less than 250 letters.")
                               .Must(IsValidName).WithMessage("{PropertyName} should be all letters.");
            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty.")
                            .MaximumLength(250).WithMessage("{PropertyName} should be less than 250 letters.");
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty.")
                           .MaximumLength(20).WithMessage("{PropertyName} should be less than 20 letters");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("{PropertyName} should be not empty.")
                           .MaximumLength(50).WithMessage("{PropertyName} should be less than 50 letters.")
                           .EmailAddress();
            RuleFor(x => x.Status).Must(x => x >= 0).WithMessage("{PropertyName} not found!");
            RuleFor(x => x.LanguageId).Must(x => x >= 0).WithMessage("Language not found!"); 
            RuleFor(x => x.Enable).NotNull().WithMessage("{PropertyName} should be not empty.");
            RuleFor(x => x.SortOrder).Must(x => x >= 0).WithMessage("{PropertyName} should be negative number."); ;
        }

        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
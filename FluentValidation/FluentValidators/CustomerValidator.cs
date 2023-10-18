using FluentValidation;
using FluentValidationApp.Entities;

namespace FluentValidationApp.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage => "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("{PropertyName} alanı doğru formatta olmalıdır");
            RuleFor(x => x.Age).NotNull().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("{PropertyName} alanı 18 ile 60 arasında olmalıdır");
            //Custom Validator
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18 yaşından büyük olmalıdır");

            RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek=1, Bayan=2 olmalıdır.");

            RuleForEach(x=>x.Addresses).SetValidator(new AddressValidator());
        }
    }
}

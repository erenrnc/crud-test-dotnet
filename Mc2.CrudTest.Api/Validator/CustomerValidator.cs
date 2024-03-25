using FluentValidation;
using Mc2.CrudTest.Api.Models;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Api.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.BankAccountNumber)
                .NotEmpty()
                .Must(BeAValidBankAccountNumber)
                .WithMessage("Invalid bank account number");

            RuleFor(x => x.PhoneNumber)
                .SetValidator(new PhoneNumberValidator());
        }

        private bool BeAValidBankAccountNumber(string accountNumber)
        {
            Regex _accountNumberRegex = new Regex(@"^\d{6,10}$");

            if (string.IsNullOrEmpty(accountNumber))
            {
                return false;
            }
            //For example, it would match 123456, 9876543210, but not 12345 or 12345678901
            return _accountNumberRegex.IsMatch(accountNumber);
        }
    }
}

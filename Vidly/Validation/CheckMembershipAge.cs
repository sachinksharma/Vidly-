using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Validation
{
    public class CheckMembershipAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MemberShipTypeId == MembershipType.PayAsYouGo || customer.MemberShipTypeId == MembershipType.Unknown)
            {
                return ValidationResult.Success;
            }

            if (customer.DateOfBirth == null)
                return new ValidationResult("Date of birth is required");
            var age = DateTime.Today.Year - customer.DateOfBirth.Year;

            return age > 18 ? ValidationResult.Success : new ValidationResult("Member should be 18 year age");

        }
    }
}
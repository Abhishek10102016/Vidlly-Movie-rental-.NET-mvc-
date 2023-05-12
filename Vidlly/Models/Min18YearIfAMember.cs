using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidlly.Models
{
    public class Min18YearIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
                if (customer.MembershipTypeId == MembershipType.unknown || 
                    customer.MembershipTypeId == MembershipType.payAsYouGo)
                return (ValidationResult.Success);
            if (customer.Birthdate== null)
                return new ValidationResult("birth date is required");
            var age= DateTime.Today.Year - customer.Birthdate.Value.Year;
            if (age >= 18) return (ValidationResult.Success);
            else return new ValidationResult("shoould be atleast 18 years old");
        }
    }
}
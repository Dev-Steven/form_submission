using System;
using System.ComponentModel.DataAnnotations;
namespace formSub.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        [Display(Name="FirstName:")]
        public string FirstName {get;set;}

        [Required]
        [MinLength(4)]
        public string LastName {get;set;}

        [Required]
        [DataType(DataType.Date)]
        [FutureDate]
        [Display(Name="Date of Birth")]
        public string Birthday {get;set;}

        [Required]
        [Range(0, 100)]
        public int Age {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get;set;}
    }

    public class FutureDateAttribute : ValidationAttribute
    {
         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime bday = Convert.ToDateTime(value);
            DateTime currentDate = DateTime.Now;
            if(bday>currentDate)
            {
                return new ValidationResult("Not a valid birthday");
            }
            return ValidationResult.Success;
        }
    }
}

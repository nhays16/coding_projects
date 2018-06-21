using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner_EF.Models
{
    public class Wedding{

        [Key]
        public int wedding_id {get; set;}

        [Display(Name="Bride's First Name")]
        [Required]
        public string bride {get; set;}

        [Display(Name="Groom's First Name")]
        [Required]
        public string groom {get; set;}

        [Display(Name="Wedding Date")]
        [Required]
        [FutureDate]
        [DataType(DataType.Date)]
        public DateTime date {get; set;}

        [Display(Name="Wedding Address")]
        [Required]
        public string address {get; set;}

        public int user_id {get; set;}

        public User Creator {get; set;}

        public List<Guest> Attendees {get; set;}
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(!(value is DateTime))
                return new ValidationResult("Not a DATE!");

            DateTime theDate = (DateTime)value;
            if(theDate <= DateTime.Now)
                return new ValidationResult("Date must be in the future!");
            return ValidationResult.Success;
        }
    }
}
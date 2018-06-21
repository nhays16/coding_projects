using System;
using System.ComponentModel.DataAnnotations;


namespace Wall.Models
{
    public class User
    {
        [Display(Name="First Name")]
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string first_name {get; set;}

        [Display(Name="Last Name")]
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string last_name {get; set;}

        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        public string email {get; set;}

        [Display(Name="Password")]
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password {get; set;}

        [Display(Name="Confirm")]
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirm {get; set;}
    }

    public class LogUser
    {
        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        public string logemail {get; set;}

        [Display(Name="Password")]
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string logpassword {get; set;}
    }
}
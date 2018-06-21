using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bank_Accounts.Models
{
    public class User
    {
        [Key]
        public int user_id {get; set;}

        [Display(Name="First Name")]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters long")]
        [Required]
        public string first_name {get; set;}

        [Display(Name="Last Name")]
        [MinLength(2, ErrorMessage="Last name must be at least 2 characters long")]
        [Required]
        public string last_name {get; set;}

        [Display(Name="Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email {get; set;}

        [Display(Name="Password")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters in length")]
        public string password {get; set;}

        public float balance {get; set;}

        public List<Withdrawal> withdrawals {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

        public User()
        {
            withdrawals = new List<Withdrawal>();
        }
    }

     public class NewUser : User{

        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage="Passwords do not match")]
        public string confirm {get; set;}
    }

    public class LoginUser{
        
        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string log_email {get; set;}

        [Display(Name="Password")]
        [Required]
        [DataType(DataType.Password)]
        public string log_password {get; set;}
            
    }
}
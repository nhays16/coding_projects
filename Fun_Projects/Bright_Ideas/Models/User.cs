using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrightIdeas.Models
{
    public class User{

        [Key]
        public int user_id {get; set;}

        [Display(Name="Name")]
        [MinLength(2, ErrorMessage="Name must be at least 2 characters long")]
        [Required]
        public string name {get; set;}

        [Display(Name="Alias")]
        [MinLength(2, ErrorMessage="Alias must be at least 2 characters long")]
        [Required]
        public string alias {get; set;}

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

        public List<Idea> MyIdeas {get; set;}

        public List<Like> MyLikes {get; set;}

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

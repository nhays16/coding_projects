using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class Review
    {
        [Key]
        public int reviewid {get; set;}

        [Display(Name="Reviewer Name")]
        [Required]
        public string reviewer {get; set;}

        [Display(Name="Restaurant Name")]
        [Required]
        public string restaurant {get; set;}

        [Display(Name="Review")]
        [Required]
        [MinLength(10)]
        public string content {get; set;}

        [Display(Name="Date of Visit")]
        [Required]
        public DateTime visit {get; set;}

        [Display(Name="Stars")]
        [Required]
        public int stars {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Lost_in_the_Woods.Models
{
    public abstract class BaseEntity {}
    public class Trail: BaseEntity
    {
        [Key]
        public long id { get; set;}
        
        [Display(Name="Trail Name")]
        [Required]
        public string trail_name {get; set;}


        [Display(Name="Description")]
        [MinLength(10)]
        public string description {get; set;}


        [Display(Name="Trail Length")]
        [RegularExpression(@"^([0-9]+)")]
        public double trail_length {get; set;}


        [Display(Name="Elevation Change")]
        [RegularExpression(@"^([0-9]+)")]
        public int elev_change {get; set;}


        [Display(Name="Longitude")]
        [RegularExpression(@"^((0\d\d|1[0-7]\d)-(0\d|[1-5]\d)\.\d\d|180-00.00)\s[EW]")]
        public float longitude {get; set;} 

        [Display(Name="Latitude")]
        [RegularExpression(@"^(([0-8]\d)-(0\d|[1-5]\d)\.\d\d|90-00.00)\s[NS]")]
        public float latitude {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Dojo_League.Models
{

    public class Ninja: BaseEntity
    {
        [Key]
        public long ninja_id {get; set;}

        [Display(Name="Ninja Name")]
        [Required]
        public string name {get; set;}

        [Display(Name="Ninjaing Level (1-10)")]
        [Required]
        public int level {get; set;}

        [Display(Name="Optional Description")]
        public string description {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

        public Dojo dojo {get; set;}
    }
}
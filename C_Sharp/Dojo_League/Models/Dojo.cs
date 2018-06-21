using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Dojo_League.Models
{
    public abstract class BaseEntity{}
    public class Dojo : BaseEntity
    {
        public Dojo(){
            ninjas = new List<Ninja>();
        }

        [Key]
        public long dojo_id {get; set;}

        [Display(Name="Dojo Name")]
        [Required]
        public string dojo_name {get; set;}

        [Display(Name="Dojo Location")]
        [Required]
        public string location {get; set;}

        [Display(Name="Additional Dojo Information")]
        public string desc {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

        public ICollection<Ninja> ninjas {get; set;}
    }
}
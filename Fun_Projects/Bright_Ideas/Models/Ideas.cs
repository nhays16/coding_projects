using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrightIdeas.Models
{
    public class Idea
    {
        [Key]
        public int idea_id {get; set;}

        public string content {get; set;}

        public int user_id {get; set;}

        public User creator {get; set;}

        public List<Like> likes {get; set;}
    }
    
}
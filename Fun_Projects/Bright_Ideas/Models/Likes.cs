using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrightIdeas.Models
{
    public class Like
    {
        [Key]
        public int like_id {get; set;}

        public int user_id {get; set;}

        public int idea_id {get; set;}

        public User liker {get; set;}
    }

}
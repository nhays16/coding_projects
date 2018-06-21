using System;
using System.ComponentModel.DataAnnotations;


namespace Wall.Models
{
    public class Message
    {
        [Display(Name="Message")]
        [Required]
        public string message {get; set;}

    }

    public class Comment
    {
        [Display(Name="Comment on this Post")]
        [Required]
        public string comment {get; set;}
        public int messageID {get; set;}
    }

    public class ContentModels
    {
        public Message MessagePost {get; set;}
        
        public Comment CommentPost {get; set;}
    }
}
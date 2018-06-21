using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wedding_Planner_EF.Models
{
    public class Guest{

        [Key]
        public int guest_id {get; set;}

        public int user_id {get; set;}

        public int wedding_id {get; set;}

        public User Attendee {get; set;}

        public Wedding Attending {get; set;}
    }
}
using System;
using System.Collections.Generic;

namespace BrightIdeas.Models
{
    public class DashboardModel
    {
        public List<Idea> PopularIdeas {get; set;}

        public Idea NewIdea {get; set;}

        public User LoggedUser {get; set;}
    }
}
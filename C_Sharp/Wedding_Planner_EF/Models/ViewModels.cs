using System;
using System.Collections.Generic;

namespace Wedding_Planner_EF.Models
{
    public class DashboardViewModel{

        public User UserId {get; set;}

        public List<Wedding> AllWeddings {get; set;}
    }
}
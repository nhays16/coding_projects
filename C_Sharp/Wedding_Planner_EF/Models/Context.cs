using System;
using Microsoft.EntityFrameworkCore;

namespace Wedding_Planner_EF.Models
{
    public class PlannerContext : DbContext
    {
        public PlannerContext(DbContextOptions options) : base(options) { }
    
        public DbSet<User> users {get; set;}

        public DbSet<Wedding> weddings {get; set;}

        public DbSet<Guest> guests {get; set;}    
    }
}
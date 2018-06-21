using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Models
{
    public class ReviewContext : DbContext{

        public ReviewContext(DbContextOptions options) : base(options) {}

        public DbSet<Review> reviews {get; set;}
    }
}
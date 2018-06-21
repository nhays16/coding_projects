using System;
using Microsoft.EntityFrameworkCore;
using Bank_Accounts.Models;

namespace Bank_Accounts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> users {get; set;}

        public DbSet<Withdrawal> withdrawals {get; set;}
    }
}
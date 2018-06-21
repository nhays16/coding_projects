using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_Accounts.Models
{
    public class Withdrawal
    {
        [Key]
        public int withdrawal_id {get; set;}

        public int user_id {get; set;}

        public User user {get; set;}

        public float amount {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}
    }
}
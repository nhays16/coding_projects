using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bank_Accounts.Models
{
    public class AccountViewModel
    {
        public User UserId {get; set;}

        public List<Withdrawal> AllWithdrawals {get; set;}
    }
}
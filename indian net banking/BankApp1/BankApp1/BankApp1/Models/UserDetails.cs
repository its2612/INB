using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp1.Models
{
    public class UserDetails
    {
        public int userid { set; get; }
        public string balance { set; get; }
        public string AccountNumber { get; set; }
        public string Amount { set; get; }
    }
}
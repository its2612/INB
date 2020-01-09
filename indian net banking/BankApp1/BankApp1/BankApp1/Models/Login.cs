using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp1.Models
{
    public class Login
    {
            public string UserName { set; get; }
            public string Password { set; get; }     
    }
    public class Registration : CustomerRequestAccount { }
    public class Transaction : TransactionTable { }
    public class contactform1 : ContactForm { }
}
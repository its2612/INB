using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp1.Models
{
    public class Bankstatement
    {
        public string AccountNumber { get; set; }
        public string BenificiaryName { get; set; }
        public string IFSC { get; set; }
        public string Branch { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
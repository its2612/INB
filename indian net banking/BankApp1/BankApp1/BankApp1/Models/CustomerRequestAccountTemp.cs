using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp1.Models
{
    public class CustomerRequestAccountTemp
    {
        public int CustomerId { get; set; }
        public string CustomerBalance { get; set; }
        public string AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public string BankBranch { get; set; }
        public Nullable<int> CustomerMobileNumber { get; set; }
        public string BranchIFSC { get; set; }
      

    }
}
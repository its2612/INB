//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankApp1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransactionTable
    {
        public int UserId { get; set; }
        public string AccountNumber { get; set; }
        public string BenificiaryName { get; set; }
        public string IFSC { get; set; }
        public string Branch { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
    
        public virtual CustomerCredential CustomerCredential { get; set; }
    }
}

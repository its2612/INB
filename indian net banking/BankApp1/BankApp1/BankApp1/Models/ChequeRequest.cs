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
    
    public partial class ChequeRequest
    {
        public int ChequeNumber { get; set; }
        public string INBAccountNumber { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string AccountHolderName { get; set; }
        public string ChequeAccountNumber { get; set; }
        public string ChequeBranchName { get; set; }
        public string BankBranch { get; set; }
        public Nullable<int> MobileNumber { get; set; }
        public string ChequeStatus { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BankAppEntities3 : DbContext
    {
        public BankAppEntities3()
            : base("name=BankAppEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CustomerCredential> CustomerCredentials { get; set; }
        public virtual DbSet<CustomerRequestAccount> CustomerRequestAccounts { get; set; }
        public virtual DbSet<TransactionTable> TransactionTables { get; set; }
    }
}

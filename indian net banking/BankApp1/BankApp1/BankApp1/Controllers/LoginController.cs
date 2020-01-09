using BankApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BankApp1.Controllers
{
    public class LoginController : ApiController
    {
        [Route("Api/Login/RegisterCustomer")]
        [HttpPost]
        public object RegisterCustomer(Registration Lvm)
        {
            try
            {
                BankAppEntities db = new BankAppEntities();
                CustomerRequestAccount Em = new CustomerRequestAccount();
                if (Em.CustomerId == 0)
                {
                    Em.AccountType = Lvm.AccountType;
                    Em.BankState = Lvm.BankState;
                    Em.BankCity = Lvm.BankCity;
                    Em.BankBranch = Lvm.BankBranch;
                    Em.BranchIFSC = Lvm.BranchIFSC;
                    Em.CustomerName = Lvm.CustomerName;
                    Em.CustomerGender = Lvm.CustomerGender;
                    Em.CustomerDOB = Lvm.CustomerDOB;
                    Em.CustomerMobileNumber = Lvm.CustomerMobileNumber;
                    Em.CustomerBalance = Lvm.CustomerBalance;
                    Em.CustomerAadharCardNumber = Lvm.CustomerAadharCardNumber;
                    Em.CustomerEmailId = Lvm.CustomerEmailId;
                    Em.CustomerAddress = Lvm.CustomerAddress;
                    Em.CustomerState = Lvm.CustomerState;
                    Em.CustomerCity = Lvm.CustomerCity;
                    Em.CustomerPIN = Lvm.CustomerPIN;
                    db.CustomerRequestAccounts.Add(Em);
                    db.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }

        [Route("Api/Login/UserLogin")]
        [HttpPost]
        public Response Login(Login Lg)
        {
            BankAppEntities DB = new BankAppEntities();
            var Obj = DB.Usp_Login(Lg.UserName, Lg.Password).ToList<Usp_Login_Result>().FirstOrDefault();
            if (Obj.Status == 0)
                return new Response { Status = "Invalid", Message = "Invalid User." };
            if (Obj.Status == -1)
                return new Response { Status = "Inactive", Message = "User Inactive." };
            else
                return new Response { Status = "Success", Message = Lg.UserName };
        }


        [Route("Api/Login/UpdateCustomerBalance")]
        [HttpPost]
        public Response UpdateCustomerBalance(UserDetails ud)
        {
            using (var ctx = new BankAppEntities())
            {

                var temp1 = (from c in ctx.CustomerCredentials
                             join cr in ctx.CustomerRequestAccounts on c.CustomerId equals cr.CustomerId
                             where c.UserId == ud.userid
                             select new CustomerRequestAccountTemp()
                             {
                                 CustomerId = c.CustomerId,
                                 CustomerBalance = cr.CustomerBalance
                             }).FirstOrDefault();

                if (Convert.ToInt32(temp1.CustomerBalance) > Convert.ToInt32(ud.balance))
                {
                    var std = ctx.CustomerRequestAccounts.FirstOrDefault(x => x.CustomerId == temp1.CustomerId);
                    std.CustomerBalance = (Convert.ToInt32(temp1.CustomerBalance) - Convert.ToInt32(ud.balance)).ToString();
                    ctx.SaveChanges();

                    return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };
                }

                else
                {
                    return new Response
                    { Status = "Insufficient Balance", Message = "Transaction Failed." };
                }
            }
        }


        [Route("Api/Login/GetCustomerBalance")]
        [HttpPost]
        public Dictionary<string, string> GetCustomerBalance(UserDetails us)
        {
            using (var ctx = new BankAppEntities())
            {
                var map = new Dictionary<string, string>();

                var temp1 = (from c in ctx.CustomerCredentials
                             join cr in ctx.CustomerRequestAccounts on c.CustomerId equals cr.CustomerId
                             where c.UserId == us.userid
                             select new CustomerRequestAccountTemp()
                             {
                                 CustomerId = c.CustomerId,
                                 CustomerBalance = cr.CustomerBalance
                             }).FirstOrDefault();

                map.Add("body", temp1.CustomerBalance);

                return map;

            }
        }

        [Route("Api/Login/GetCustomerName")]
        [HttpPost]
        public Dictionary<string, string> GetCustomerName(UserDetails us)
        {
            using (var ctx = new BankAppEntities())
            {
                var map = new Dictionary<string, string>();

                var temp1 = (from c in ctx.CustomerCredentials
                             join cr in ctx.CustomerRequestAccounts on c.CustomerId equals cr.CustomerId
                             where c.UserId == us.userid
                             select new CustomerRequestAccountTemp()
                             {
                                 CustomerId = c.CustomerId,
                                 CustomerName = cr.CustomerName
                             }).FirstOrDefault();

                map.Add("body", temp1.CustomerName);

                return map;

            }
        }

        [Route("Api/Login/GetCustomerAccountDetails")]
        [HttpPost]
        public Dictionary<string, string> GetCustomerAccountDetails(int userid)
        {
            using (var ctx = new BankAppEntities())
            {
                var map = new Dictionary<string, string>();
                UserDetails us = new UserDetails();
                us.userid = userid;
                var temp1 = (from c in ctx.CustomerCredentials
                             join cr in ctx.CustomerRequestAccounts on c.CustomerId equals cr.CustomerId
                             where c.UserId == us.userid
                             select new CustomerRequestAccountTemp()
                             {
                                 CustomerId = c.CustomerId,
                                 CustomerName = cr.CustomerName,
                                 BankBranch = cr.BankBranch,
                                 CustomerMobileNumber = cr.CustomerMobileNumber,
                                 AccountNumber = c.AccountNumber,
                                 BranchIFSC = cr.BranchIFSC,
                                 CustomerBalance = cr.CustomerBalance

                             }).FirstOrDefault();

                map.Add("accno", temp1.AccountNumber);
                map.Add("bn", temp1.BankBranch);
                map.Add("ifsc", temp1.BranchIFSC);
                map.Add("branch", temp1.BankBranch);
                map.Add("mobileno", temp1.CustomerMobileNumber.ToString());
                map.Add("amount", temp1.CustomerBalance);
                map.Add("name", temp1.CustomerName);
                return map;

            }
        }

        [Route("Api/Login/GetCustomerAccountNumber")]
        [HttpPost]
        public Dictionary<string, string> GetCustomerAccountNumber(UserDetails us)
        {
            using (var ctx = new BankAppEntities())
            {
                var map = new Dictionary<string, string>();

                var temp1 = (from c in ctx.CustomerCredentials
                             where c.UserId == us.userid
                             select new CustomerRequestAccountTemp()
                             {
                                 CustomerId = c.CustomerId,
                                 AccountNumber = c.AccountNumber
                             }).FirstOrDefault();

                map.Add("body", temp1.AccountNumber);

                return map;

            }
        }

        [Route("Api/Login/FundTransfer")]
        [HttpPost]
        public object FundTransfer(Transaction transaction)
        {
            try
            {
                BankAppEntities1 db = new BankAppEntities1();
                TransactionTable tt = new TransactionTable();
                if (tt.UserId == 0)
                {
                    tt.UserId = transaction.UserId;
                    tt.AccountNumber = transaction.AccountNumber;
                    tt.BenificiaryName = transaction.BenificiaryName;
                    tt.IFSC = transaction.IFSC;
                    tt.Branch = transaction.Branch;
                    tt.Date = transaction.Date;
                    tt.Amount = transaction.Amount;
                    tt.Remarks = transaction.Remarks;
                      db.TransactionTables.Add(tt);
                    db.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }


        [Route("Api/Login/UpdateBalanceFundTransferDecrement")]
        [HttpPost]
        public object  UpdateBalanceFundTransferDecrement(UserDetails ud)
        {
            using (var ctx = new BankAppEntities())
            {

                var temp1 = (from c in ctx.CustomerCredentials
                             join cr in ctx.CustomerRequestAccounts on c.CustomerId equals cr.CustomerId
                             where c.UserId == ud.userid
                             select new CustomerRequestAccountTemp()
                             {
                                 CustomerId = c.CustomerId,
                                 CustomerBalance = cr.CustomerBalance
                             }).FirstOrDefault();

                if (Convert.ToInt32(temp1.CustomerBalance) > Convert.ToInt32(ud.Amount))
                {
                    var std = ctx.CustomerRequestAccounts.FirstOrDefault(x => x.CustomerId == temp1.CustomerId);
                    std.CustomerBalance = (Convert.ToInt32(temp1.CustomerBalance) - Convert.ToInt32(ud.Amount)).ToString();
                    ctx.SaveChanges();

                    return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };
                }

                else
                {
                    return new Response
                    { Status = "Insufficient Balance", Message = "Transaction Failed." };
                }
            }
        }

        [Route("Api/Login/UpdateBalanceFundTransferInc")]
        [HttpPost]
        public object UpdateBalanceFundTransferInc(UserDetails ud)
        {
            using (var ctx = new BankAppEntities())
            {

                var temp1 = (from c in ctx.CustomerCredentials
                             join cr in ctx.CustomerRequestAccounts on c.CustomerId equals cr.CustomerId
                             where c.AccountNumber == ud.AccountNumber
                             select new CustomerRequestAccountTemp()
                             {
                                 CustomerId = c.CustomerId,
                                 CustomerBalance = cr.CustomerBalance
                             }).FirstOrDefault();

               
                    var std = ctx.CustomerRequestAccounts.FirstOrDefault(x => x.CustomerId == temp1.CustomerId);
                    std.CustomerBalance = (Convert.ToInt32(temp1.CustomerBalance) + Convert.ToInt32(ud.Amount)).ToString();
                    ctx.SaveChanges();

                return new Response
                { Status = "Success", Message = "Transaction success." };
            
             }
        }

        //[Route("Api/Login/GetCustomerBankStatement")]
        //[HttpPost]
        //public Dictionary<string, string> GetCustomerBankStatement(string accno)
        //{
        //    using (var ctx = new BankAppEntities8())
        //    {
        //        var map = new Dictionary<string, string>();


        //        var temp1 = (from c in ctx.TransactionTables
        //                     where c.AccountNumber == accno
        //                     select new Bankstatement()
        //                     {
        //                         AccountNumber = c.AccountNumber,
        //                         BenificiaryName = c.BenificiaryName,
        //                         IFSC = c.IFSC,
        //                         Branch = c.Branch,
        //                         Date = c.Date,
        //                         Amount = c.Amount
        //                     }).FirstOrDefault();


        //        map.Add("accno", temp1.AccountNumber);
        //        map.Add("bn", temp1.BenificiaryName);
        //        map.Add("ifsc", temp1.IFSC);
        //        map.Add("branch", temp1.Branch);
        //        map.Add("date", temp1.Date.ToString());
        //        map.Add("amount", temp1.Amount.ToString());

        //        return map;
        //    }

        //}

        [Route("Api/Login/GetCustomerBankStatement")]
        [HttpPost]
        public List<Bankstatement> GetCustomerBankStatement(string accno)
        {
            using (var ctx = new BankAppEntities8())
            {
                var map = new Dictionary<string, string>();


                var temp = (from c in ctx.TransactionTables
                            where c.AccountNumber == accno
                            select new Bankstatement()
                            {
                                AccountNumber = c.AccountNumber,
                                BenificiaryName = c.BenificiaryName,
                                IFSC = c.IFSC,
                                Branch = c.Branch,
                                Date = c.Date,
                                Amount = c.Amount
                            }).ToList();

              

                return temp;
            }

        }

        [Route("Api/Login/ContactFormDetails")]
        [HttpPost]
        public object ContactFormDetails(contactform1 cc)
        {
            try
            {

                BankAppEntities5 cf = new BankAppEntities5();
                ContactForm Em = new ContactForm();
                if (Em.UserId == 0)
                {
                    Em.UserId = cc.UserId;
                    Em.Name = cc.Name;
                    Em.BankAccountNumber = cc.BankAccountNumber;
                    Em.Query = cc.Query;
                    cf.ContactForms.Add(Em);
                    cf.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }


        BankAppEntities5 dbc = new BankAppEntities5();
        // GET: api/ContactForms
        public IQueryable<ContactForm> GetContactForms()
        {
            return dbc.ContactForms;
        }


        //get

        //private BankAppEntities1 _db;
        //public TransactionController()
        //{
        //    _db = new BankAppEntities1();
        //}
        //public IEnumerable<TransactionTable> GetEmployees()
        //{
        //    return _db.TransactionTables.ToList();
        //}



        //[Route("Api/Login/GetCustomerBalance")]
        //[HttpPost]
        //public Dictionary<string, string> GetCustomerBalance(int userid)
        //{
        //    using (var ctx = new BankAppEntities())
        //    {
        //        var map = new Dictionary<string, string>();

        //        var temp1 = (from c in ctx.CustomerCredentials
        //                     join cr in ctx.CustomerRequestAccounts on c.CustomerId equals cr.CustomerId
        //                     where c.UserId == userid
        //                     select new CustomerRequestAccountTemp()
        //                     {
        //                         CustomerId = c.CustomerId,
        //                         CustomerBalance = cr.CustomerBalance
        //                     }).FirstOrDefault();

        //        map.Add("body", temp1.CustomerBalance);

        //        return map;

        //        var cid1 = ctx.Database.SqlQuery<int>("Select CustomerId from CustomerCredential where UserId='" + userid + "'").FirstOrDefault();
        //        var camount = ctx.CustomerRequestAccounts.SqlQuery("Select CustomerBalance from CustomerRequestAccount where CustomerId='" + cid + "'").FirstOrDefault<CustomerRequestAccount>().ToString();

        //        var cid = 0;
        //        var temp1 = ctx.CustomerCredentials.FirstOrDefault(x => x.UserId == userid);
        //        if (temp1 != null)
        //        {
        //            cid1 = temp1.CustomerId;
        //        }

        //    }
        //}

        //[Route("Api/Login/GetCustomerBalanceByAccountno")]
        //[HttpPost]
        //public string GetCustomerBalanceByAccountno(string accountNumber)
        //{
        //    using (var ctx = new BankAppEntities())
        //    {
        //        //var map = new Dictionary<string, string>();

        //        var temp1 = (from c in ctx.CustomerCredentials
        //                     join cr in ctx.CustomerRequestAccounts on c.CustomerId equals cr.CustomerId
        //                     where c.AccountNumber == accountNumber
        //                     select new CustomerRequestAccountTemp()
        //                     {
        //                         CustomerId = c.CustomerId,
        //                         CustomerBalance = cr.CustomerBalance
        //                     }).FirstOrDefault();

        //        //map.Add("body", temp1.CustomerBalance);

        //        return temp1.CustomerBalance;

        //    }
        //}
    }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BankApp1.Models;

namespace BankApp1.Controllers
{
    public class ChequeRequestsController : ApiController
    {
        private BankAppEntities4 db = new BankAppEntities4();

        // GET: api/ChequeRequests
        public IQueryable<ChequeRequest> GetChequeRequests()
        {
            return db.ChequeRequests;
        }

    }
}
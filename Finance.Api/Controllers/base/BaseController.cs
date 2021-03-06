﻿using System.Web.Mvc;
using Finance.Logic.Crm;
using Finance.Logic.Indentity;
using Generic.Framework.Interfaces.Entity;

namespace Finance.Controllers.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IPersistanceFactory _persistanceFactory;

        private CustomerService _serviceCustomer;
        protected CustomerService CustomerService => _serviceCustomer ?? (_serviceCustomer = new CustomerService(_persistanceFactory));

        private PartyService _serviceParty;
        protected PartyService PartyService => _serviceParty ?? (_serviceParty = new PartyService(_persistanceFactory));

        private DealershipService _serviceDealership;
        protected DealershipService DealershipService => _serviceDealership ?? (_serviceDealership = new DealershipService(_persistanceFactory));

        protected BaseController()
        {
        }

        protected BaseController(
            IPersistanceFactory persistanceFactory)
        {
            _persistanceFactory = persistanceFactory;

        }
    }
}

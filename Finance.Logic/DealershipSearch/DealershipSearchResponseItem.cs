﻿
using System;
using Finance.Logic.Crm;
using Finance.Logic.Deals;


namespace Finance.Logic.DealershipSearch
{
    public class DealershipSearchResponseItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContactName { get; set; }

        public string PhoneNumber { get; set; }

        public string CellNumber { get; set; }

        public string Email { get; set; }
        
    }
}
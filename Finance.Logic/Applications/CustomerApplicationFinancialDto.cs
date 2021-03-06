﻿using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Applications
{
    public class CustomerApplicationFinancialDto : IGenericDto<CustomerApplicationFinancial>, IGuidNullableId
    {

        #region Fields

        public Guid? Id { get; set; }

        [Required]
        public string Financial { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        public string EnteredBy { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #endregion

        #region IGenericDto
        private static void Map()
        {
            Mapper.CreateMap<CustomerApplicationFinancialDto, CustomerApplicationFinancial>()
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());

            Mapper.CreateMap<CustomerApplicationFinancial, CustomerApplicationFinancialDto>();
                                                           
        }
        public CustomerApplicationFinancialDto() { }

        public CustomerApplicationFinancialDto(CustomerApplicationFinancial entity)
        {
            Map();
            Mapper.Map(entity, this);
        }

        public CustomerApplicationFinancial ToEntity()
        {
            Map();
            var entity = Mapper.Map<CustomerApplicationFinancial>(this);
            return entity;
        }

        public void UpdateEntity(CustomerApplicationFinancial entity)
        {
            Map();
            Mapper.Map(this, entity);
        }

        #endregion
    }
}

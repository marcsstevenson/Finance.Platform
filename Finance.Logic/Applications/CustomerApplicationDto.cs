﻿using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Finance.Logic.Shared;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Applications
{public class CustomerApplicationDto : Generic.Framework.Interfaces.IGenericDto<CustomerApplication>, IGuidNullableId
    {
        #region Fields

        public Guid? Id { get; set; }

        public bool VehicleUsePersonal { get; set; }
        public bool VehicleUseBusiness { get; set; }
        public bool VehicleUseSoleTrader { get; set; }
        public bool VehicleUseLimitedLiability { get; set; }

        /// <summary>
        /// Applicant details
        /// </summary>
        [Required]
        public PersonalEntityDto Applicant { get; set; }

        /// <summary>
        /// Spouce information 
        /// </summary>
        public PersonalEntityDto Spouce { get; set; }

        /// <summary>
        /// The date that the application was signed
        /// </summary>
        public DateTime? DateSigned { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        #endregion

        #region IGenericDto
        static CustomerApplicationDto()
        {
            Mapper.CreateMap<CustomerApplicationDto, CustomerApplication>()
                //These properties are managed by the service
                .ForMember(x => x.Number, opt => opt.Ignore())
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());
            
            Mapper.CreateMap<CustomerApplication, CustomerApplicationDto>();
        }
        public CustomerApplicationDto() { }

        public CustomerApplicationDto(CustomerApplication entity)
        {
            Mapper.Map(entity, this);
        }
        
        public CustomerApplication ToEntity()
        {
            var entity = Mapper.Map<CustomerApplication>(this);
            return entity;
        }

        public void UpdateEntity(CustomerApplication entity)
        { 
            Mapper.Map(this, entity);
        }

        #endregion
    }
}

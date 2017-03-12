using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Comms;

namespace Finance.Logic.Crm
{
    public class DealershipDto : IGenericDto<Dealership>, IGuidNullableId, IName
    {
        public Guid? Id { get; set; }

        [Required]
        public bool IsEnabled { get; set; } = true;

        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// The name of the main contact at this dealership
        /// </summary>
        public string ContactName { get; set; }

        public string Website { get; set; }
        public string Email { get; set; }

        // Phone number fields
        public string PhoneNumber { get; set; }

        // Cell number fields
        public string MobileNumber { get; set; }

        // Fax number fields
        public string FaxNumber { get; set; }

        //Bank account details
        public string BankingCompany { get; set; }
        public string BankAccountName { get; set; }
        public string BankBranchName { get; set; }
        public string BankAccountNumber { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #region IGenericDto
        private static void Map()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<DealershipDto, Dealership>()
                //These properties are managed by the repository;
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                );

            Mapper.CreateMap<Dealership, DealershipDto>();
        }
        public DealershipDto() { }

        public DealershipDto(Dealership entity)
        {
            Map();
            Mapper.Map(entity, this);
        }
        
        public Dealership ToEntity()
        {
            Map();
            var entity = Mapper.Map<Dealership>(this);
            return entity;
        }

        public void UpdateEntity(Dealership entity)
        {
            Map();
            Mapper.Map(this, entity);
        }

        #endregion
    }
}

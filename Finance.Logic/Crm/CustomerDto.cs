using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.AbstractClasses;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces;
using Generic.Framework.Interfaces.Comms;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.Crm
{
    public class CustomerDto : IGenericDto<Customer>, IGuidNullableId, IPerson, IEmail, IPhone, ICell, IFax, IBankAccount
    {
        #region Fields

        public Guid? Id { get; set; }

        public Gender? Gender { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string DriversLicenceNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The customer's visible reference - unique
        /// </summary>
        /// <example>CU0008798</example>
        [Required]
        public string Number { get; set; }

        public string Email { get; set; }

        // Phone number fields
        public string PhoneCountry { get; set; }
        public string PhoneArea { get; set; }
        public string PhoneNumber { get; set; }

        // Cell number fields
        public string CellCountry { get; set; }
        public string CellArea { get; set; }
        public string CellNumber { get; set; }

        // Fax number fields
        public string FaxCountry { get; set; }
        public string FaxArea { get; set; }
        public string FaxNumber { get; set; }

        public string SkypeName { get; set; }

        public string Website { get; set; }

        //Bank account details
        public string BankingCompany { get; set; }
        public string BankAccountName { get; set; }
        public string BankBranchName { get; set; }
        public string BankAccountNumber { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        #endregion

        #region IGenericDto
        static CustomerDto()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CustomerDto, Customer>()
                //These properties are managed by the repository;
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                );

            Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerDto>());
        }
        public CustomerDto() { }

        public CustomerDto(Customer entity)
        {
            //For reasons unknow the static initialization is not being used. TODO: sort this out or move to a startup method
            Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerDto>());

            Mapper.Map(entity, this);
        }

        //public void Populate(Customer entity)
        
        //}

        public Customer ToEntity()
        {
            //For reasons unknow the static initialization is not being used. TODO: sort this out or move to a startup method
            //Mapper.Initialize(cfg => cfg.CreateMap<CustomerDto, Customer>()
            //    //These properties are managed by the repository;
            //    .ForMember(x => x.DateCreated, opt => opt.Ignore())
            //    .ForMember(x => x.DateModified, opt => opt.Ignore())
            //    );

            var entity = Mapper.Map<Customer>(this);
            return entity;
        }

        public void UpdateEntity(Customer entity)
        { 
            //For reasons unknow the static initialization is not being used. TODO: sort this out or move to a startup method
            //Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerDto>());

            Mapper.Map(this, entity);
        }

        #endregion
    }
}

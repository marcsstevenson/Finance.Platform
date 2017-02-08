﻿using System;
using AutoMapper;
using Generic.Framework.Interfaces;
using Generic.Framework.Enumerations;
using Generic.Framework.Interfaces.Comms;
using Generic.Framework.Interfaces.Personal;

namespace Finance.Logic.FinanceCompanies
{
    public class AccountManagerDto : IGenericDto<AccountManager>, IPerson, IEmail, ICell, IPhone
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #region IGenericDto

        private static void Map()
        {
            Mapper.CreateMap<AccountManagerDto, AccountManager>()
                //These properties are managed by the repository;
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());
            Mapper.CreateMap<AccountManager, AccountManagerDto>();
        }
        public AccountManagerDto() { }

        public AccountManagerDto(AccountManager entity)
        {
            Map();
            Mapper.Map(entity, this);
        }

        public AccountManager ToEntity()
        {
            Map();
            var entity = Mapper.Map<AccountManager>(this);
            return entity;
        }

        public void UpdateEntity(AccountManager entity)
        {
            Map();
            Mapper.Map(this, entity);
        }

        #endregion
    }
}

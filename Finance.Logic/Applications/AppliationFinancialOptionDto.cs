using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Applications
{
    public class AppliationFinancialOptionDto : IGenericDto<AppliationFinancialOption>, IGuidNullableId, IName
    {
        public Guid? Id { get; set; }
        public AppliationFinancialType AppliationFinancialType { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        #region IGenericDto
        static AppliationFinancialOptionDto()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AppliationFinancialOptionDto, AppliationFinancialOption>()
                //These properties are managed by the repository;
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                );

            Mapper.Initialize(cfg => cfg.CreateMap<AppliationFinancialOption, AppliationFinancialOptionDto>());
        }
        public AppliationFinancialOptionDto() { }

        public AppliationFinancialOptionDto(AppliationFinancialOption entity)
        {
            Mapper.Map(entity, this);
        }

        //public void Populate(AppliationFinancial entity)

        //}

        public AppliationFinancialOption ToEntity()
        {
            var entity = Mapper.Map<AppliationFinancialOption>(this);
            return entity;
        }

        public void UpdateEntity(AppliationFinancialOption entity)
        {
            Mapper.Map(this, entity);
        }

        #endregion
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Configuration
{

    public class LeadOriginDto : IGenericDto<LeadOrigin>, IGuidNullableId, IName
    {
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #region IGenericDto
        private static void Map()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<LeadOriginDto, LeadOrigin>()
                //These properties are managed by the repository;
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                );

            Mapper.CreateMap<LeadOrigin, LeadOriginDto>();
        }
        public LeadOriginDto() { }

        public LeadOriginDto(LeadOrigin entity)
        {
            Map();
            Mapper.Map(entity, this);
        }

        public LeadOrigin ToEntity()
        {
            Map();
            var entity = Mapper.Map<LeadOrigin>(this);
            return entity;
        }

        public void UpdateEntity(LeadOrigin entity)
        {
            Map();
            Mapper.Map(this, entity);
        }

        #endregion
    }
}

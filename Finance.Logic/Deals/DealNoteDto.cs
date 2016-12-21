using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Deals
{
    public class DealNoteDto : IGenericDto<DealNote>, IGuidNullableId
    {
        #region Fields

        public Guid? Id { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public Guid DealId { get; set; }
        
        public string EnteredBy { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #endregion

        #region IGenericDto
        private static void Map()
        {
            Mapper.CreateMap<DealNoteDto, DealNote>()
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());
            
            Mapper.CreateMap<DealNote, DealNoteDto>();
        }
        public DealNoteDto() { }

        public DealNoteDto(DealNote entity)
        {
            Map();
            Mapper.Map(entity, this);
        }
        
        public DealNote ToEntity()
        {
            Map();
            var entity = Mapper.Map<DealNote>(this);
            return entity;
        }

        public void UpdateEntity(DealNote entity)
        { 
            Map();
            Mapper.Map(this, entity);
        }

        #endregion
    }
}

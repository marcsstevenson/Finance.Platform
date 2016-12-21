using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Applications
{
    public class CustomerApplicationNoteDto : IGenericDto<CustomerApplicationNote>, IGuidNullableId
    {
        #region Fields

        public Guid? Id { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        
        public string EnteredBy { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        #endregion

        #region IGenericDto
        private static void Map()
        {
            Mapper.CreateMap<CustomerApplicationNoteDto, CustomerApplicationNote>()
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore());
            
            Mapper.CreateMap<CustomerApplicationNote, CustomerApplicationNoteDto>();
        }
        public CustomerApplicationNoteDto() { }

        public CustomerApplicationNoteDto(CustomerApplicationNote entity)
        {
            Map();
            Mapper.Map(entity, this);
        }
        
        public CustomerApplicationNote ToEntity()
        {
            Map();
            var entity = Mapper.Map<CustomerApplicationNote>(this);
            return entity;
        }

        public void UpdateEntity(CustomerApplicationNote entity)
        { 
            Map();
            Mapper.Map(this, entity);
        }

        #endregion
    }
}

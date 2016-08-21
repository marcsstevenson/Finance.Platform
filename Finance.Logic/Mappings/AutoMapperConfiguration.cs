using AutoMapper;
using Finance.Logic.Crm;

namespace Finance.Logic.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void CreateMappings()
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDto>());
            //var mapper = config.CreateMapper();

            Mapper.Initialize(cfg => cfg.CreateMap<CustomerDto, Customer>()
                //These properties are managed by the repository;
                .ForMember(x => x.DateCreated, opt => opt.Ignore())
                .ForMember(x => x.DateModified, opt => opt.Ignore())
                );

            Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerDto>());
        }
    }
}

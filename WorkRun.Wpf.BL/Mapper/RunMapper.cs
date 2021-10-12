using AutoMapper;
using WorkRun.Dto;

namespace WorkRun.Client.BL
{
    public class RunMapper
    {
        public static IMapper Mapper { get; set; } = GetMapper();

        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => SetMapper(cfg)); 

            return new Mapper(config);
        }

        private static void SetMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<PersonDto, PersonModel>().ReverseMap();
        }
    }
}

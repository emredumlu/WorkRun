using AutoMapper;
using WorkRun.BaseDb;
using WorkRun.Dto;

namespace WorkRun.Service
{
    public class SeviceProfile : Profile
    {
        public SeviceProfile()
        {
            SetProfile();
        }

        private void SetProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}

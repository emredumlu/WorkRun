using AutoMapper;
using System;
using System.Threading.Tasks;
using WorkRun.Dto;

namespace WorkRun.Client.BL
{
    public class PersonViewModel : BaseClientModel
    {
        private readonly IMapper _mapper = RunMapper.Mapper;
        private readonly PersonRepo _repo = new();
        public PersonViewModel()
        {
            CreatePerson();
        }

        #region prop
        private PersonModel _person;
        public PersonModel Person
        {
            get => _person;
            set
            {
                _person = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region method
        public void CreatePerson()
        {
            Person = new()
            {
                Id = Guid.NewGuid()
            };
        }

        public async Task<WorkResult> Save()
        {
            var person = _mapper.Map<PersonDto>(Person);
            var result = await _repo.Insert(person);
            if (result.IsOk) CreatePerson();
            return result;
        }
        #endregion
    }
}

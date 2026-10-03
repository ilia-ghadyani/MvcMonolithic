using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithic.Models.DomainModels.PersonAggregates;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.ApplicationServices
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IPersonRepository _personRepository;

        #region [- Ctor() -]
        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region [- Post() -]
        public async Task Post(PostPersonDto postPersonDto)
        {
            var person = new Person
            {
                FirstName = postPersonDto.FirstName,
                LastName = postPersonDto.LastName,
            };
            await _personRepository.Insert(person);
        }
        #endregion

        #region [- GetPersonById() -]
        public async Task<PutPersonDto?> GetPersonById(GetPersonByIdDto getPersonByIdDto)
        {

            var person = await _personRepository.SelectPersonById(getPersonByIdDto);

            if (person == null)
            {
                return null;
            }
            var putPersonDto = new PutPersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
            return putPersonDto;

        } 
        #endregion

        #region [- Put() -]
        public async Task Put(PutPersonDto putPersonDto)
        {
            var getPersonByIdDto = new GetPersonByIdDto
            {
                Id = putPersonDto.Id,
            };
            var person = await _personRepository.SelectPersonById(getPersonByIdDto);


            if (person == null) 
            {
                return;
            }

            person.FirstName = putPersonDto.FirstName; 
            person.LastName = putPersonDto.LastName;

            await _personRepository.Update(person);
        }
        #endregion

        #region [- GetPersonDelete() -]
        public async Task<DeletePersonDto?> GetPersonDelete(GetPersonByIdDto getPersonByIdDto)
        {
            var person = await _personRepository.SelectPersonById(getPersonByIdDto);

            if (person == null)
            {
                return null;
            }

            var deletePersonDto = new DeletePersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            return deletePersonDto;
        }  
        #endregion

        #region [- Delete() -]
        public async Task Delete(DeletePersonDto deletePersonDto)
        {
            var person = new Person
            {
                Id = deletePersonDto.Id,
                FirstName = deletePersonDto.FirstName,
                LastName = deletePersonDto.LastName
            };

            await _personRepository.Delete(person);
        }
        #endregion

        #region [- GetPersonDetails() -]
        public async Task<DetailsPersonDto?> GetPersonDetails(GetPersonByIdDto getPersonByIdDto)
        {
            var persons = await _personRepository.SelectPersonById(getPersonByIdDto);

            if (persons == null)
            {
                return null;
            }
            var detailsPersonDto = new DetailsPersonDto
            {
                Id = persons.Id,
                FirstName = persons.FirstName,
                LastName = persons.LastName
            };
            return detailsPersonDto;
        } 
        #endregion

        #region [- GetAllPerson() -]
        public async Task<List<GetPersonDto>> GetAllPerson()
        {
            var persons = await _personRepository.SelectAll();
            var getPersonDtos = new List<GetPersonDto>();
            foreach (var item in persons)
            {
                var getPersonDto = new GetPersonDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                };
                getPersonDtos.Add(getPersonDto);
            }
            return getPersonDtos;
        }
        #endregion
    }
}

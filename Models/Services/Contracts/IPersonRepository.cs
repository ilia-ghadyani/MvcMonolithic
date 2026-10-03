using MvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithic.Models.DomainModels.PersonAggregates;


namespace MvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {
        Task Insert(Person person);
        Task Update(Person person);
        Task<Person?> SelectPersonById(GetPersonByIdDto getPersonByIdDto);
        Task Delete(Person person);
        Task<List<Person>> SelectAll();
    }
}

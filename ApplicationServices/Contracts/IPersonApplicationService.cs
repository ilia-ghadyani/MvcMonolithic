using MvcMonolithic.ApplicationServices.Dtos.PersonDtos;

namespace MvcMonolithic.ApplicationServices.Contracts
{
    public interface IPersonApplicationService
    {
        Task Post(PostPersonDto postPersonDto);
        Task<PutPersonDto?> GetPersonById(GetPersonByIdDto getPersonByIdDto);
        Task Put(PutPersonDto putPersonDto);
        Task Delete(DeletePersonDto deletePersonDto);
        Task<DeletePersonDto?> GetPersonDelete(GetPersonByIdDto getPersonByIdDto);
        Task<DetailsPersonDto?> GetPersonDetails(GetPersonByIdDto getPersonByIdDto);
        Task<List<GetPersonDto>> GetAllPerson();

    }
}

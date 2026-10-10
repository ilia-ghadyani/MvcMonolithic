using Microsoft.EntityFrameworkCore;
using MvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithic.Models.DomainModels.PersonAggregates;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ProjectDbContext _projectDbContext;

        #region [- Ctor() -]
        public PersonRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        #endregion

        #region [- Insert() -]
        public async Task Insert(Person person)
        {
            try
            {
                _projectDbContext.Add(person); 
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- SelectPersonById() -]
        public async Task<Person?> SelectPersonById(GetPersonByIdDto getPersonByIdDto)  
        {
            try
            {
                return await _projectDbContext.Person.FindAsync(getPersonByIdDto.Id); 
            }
            catch (Exception)
            {

                throw;
            }
        } 
        #endregion

        #region [- Update() -]
        public async Task Update(Person person)
        {
            try
            {
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- Delete() -]
        public async Task Delete(Person person)
        {
            try
            {
                _projectDbContext.Remove(person);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [ - SelectAll() -]
        public async Task<List<Person>> SelectAll()
        {
            try
            {
                return await _projectDbContext.Person.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}

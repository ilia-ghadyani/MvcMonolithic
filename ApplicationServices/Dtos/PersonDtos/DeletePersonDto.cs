namespace MvcMonolithic.ApplicationServices.Dtos.PersonDtos
{
    public class DeletePersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}

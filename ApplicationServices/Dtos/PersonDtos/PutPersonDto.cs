namespace MvcMonolithic.ApplicationServices.Dtos.PersonDtos
{
    public class PutPersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty; 
        public string LastName { get; set; } = string.Empty;
    }
}

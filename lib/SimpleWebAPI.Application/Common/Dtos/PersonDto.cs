namespace SimpleWebAPI.Application.Common.Dtos
{
    using SimpleWebAPI.Domain.Entities;

    public class PersonDto
    {
        public PersonDto() { }

        public PersonDto(Person person)
        {
            Name = person.Name;
            Address = person.Address;
        }

        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}

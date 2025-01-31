using BUnitTest.Client.Models;

namespace BUnitTest.Client.Services
{
    public class PersonService : IPersonService
    {
        public List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe" },
                new Person { FirstName = "Jane", LastName = "Smith" }
            };
        }
    }
}

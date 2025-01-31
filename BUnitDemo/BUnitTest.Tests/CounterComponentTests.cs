using Bunit;
using Moq;
using BUnitTest.Client.Pages;
using BUnitTest.Client.Services;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.DependencyInjection;
using BUnitTest.Client.Models;
using BUnitTest.Client.Components;

namespace BUnitTest.Tests
{
    [TestClass]
    public class CounterComponentTests
    {
        [TestMethod]
        public void IncrementCount_Test1()
        {
            // Arrange
            var context = new Bunit.TestContext();
            var personService = new Mock<IPersonService>();
            personService.Setup(x => x.GetPeople()).Returns(new List<Person>());
            context.Services.AddSingleton(personService.Object);
            var component = context.RenderComponent<Counter>();


            // Act
            component.Find("button").Click();

            // Assert
            component.Find("p").MarkupMatches("<p> Current count: 1 </p>");
        }

        [TestMethod]
        public void CounterComponent_Test1()
        {
            // Arrange
            var context = new Bunit.TestContext();
            var personService = new Mock<IPersonService>();
            personService.Setup(x => x.GetPeople()).Returns(new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe" },
                new Person { FirstName = "Jane", LastName = "Smith" }
            });
            context.Services.AddSingleton(personService.Object);

            // Act
            var component = context.RenderComponent<Counter>();

            // Assert
            Assert.AreEqual(2, component.FindComponents<PersonComponent>().Count);
        }
    }
}
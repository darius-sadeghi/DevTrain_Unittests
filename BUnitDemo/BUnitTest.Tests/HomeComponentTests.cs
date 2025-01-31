using Bunit;
using BUnitTest.Client.Pages;

namespace BUnitTest.Tests
{
    [TestClass]
    public class HomeComponentTests
    {
        [TestMethod]
        public void HomeComponent_Test1()
        {
            // Arrange
            var context = new Bunit.TestContext();

            // Act
            var component = context.RenderComponent<Home>();

            // Assert
            Assert.IsTrue(component.HasComponent<Counter>());
            var counterCount = component.FindComponents<Counter>().Count;
            Assert.AreEqual(1, counterCount);
        }
    }
}

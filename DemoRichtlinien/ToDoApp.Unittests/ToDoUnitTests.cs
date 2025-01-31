using ToDoApp.Business;

namespace ToDoApp.Unittests
{
    [TestClass]
    public class ToDoUnitTests
    {
        [TestMethod]
        public void CalculateWorkingDays_Testcase1()
        {
            // Arrange
            DateTime start = new DateTime(2023, 1, 1);
            DateTime end = new DateTime(2023, 1, 31);

            // Act
            double result = ToDoUnit.CalculateWorkingDays(start, end);

            // Assert
            Assert.AreEqual(22, result);
        }

        // Andere Testfälle
        // Enddatum liegt vor Startdatum

        [TestMethod]
        public void CalculateWorkingDays_Testcase2()
        {
            DateTime start = new DateTime(2023, 2, 1);
            DateTime end = new DateTime(2023, 3, 1);

            double result = ToDoUnit.CalculateWorkingDays(start, end);

            Assert.AreEqual(21, result);
        }
    }
}
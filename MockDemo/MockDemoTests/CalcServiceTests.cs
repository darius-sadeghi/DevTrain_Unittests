using MockDemo.Services;
using Moq;

namespace MockDemoTests
{
    [TestClass]
    public sealed class CalcServiceTests
    {
        [TestMethod]
        public void DoCalc_Test1()
        {
            // Arrange
            //IDataService dataService = new DataService();
            var mockDataService = new Mock<IDataService>();
            mockDataService.Setup(m => m.GetData()).Returns(new List<int> { 1, 2, 3, 4, 5 }).Verifiable();
            //mockDataService.Setup(m => m.GetData()).Returns(new List<int> { 1, 2, 3, 4, 5 });
            ICalcService calcService = new CalcService(mockDataService.Object);

            // Act
            int result = calcService.DoCalc();

            // Assert
            Assert.AreEqual(15, result);
            mockDataService.Verify();
            //mockDataService.VerifyAll();
        }

        [TestMethod]
        public void DoDynamicCalc_Test1()
        {
            // Arrange
            //IDataService dataService = new DataService();
            var mockDataService = new Mock<IDataService>();
            mockDataService.Setup(m => m.GetDynamicData(It.IsAny<int>())).Returns((int seed) => Enumerable.Range(1, seed).ToList());
            mockDataService.Setup(m => m.GetDynamicData(It.Is<int>(x => x == 1)))
                .Callback(() => Console.WriteLine("Before returns"))
                .Returns(new List<int> { 1, 2, 3 })
                .Callback(() => Console.WriteLine("After returns"));
            ICalcService calcService = new CalcService(mockDataService.Object);
            // Act
            int result = calcService.DoDynamicCalc(1);
            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public async Task SaveData_Test1()
        {
            // Arrange
            var mockDataService = new Mock<IDataService>();
            mockDataService.Setup(m => m.GetData()).Returns(new List<int> { 1, 2, 3, 4, 5 });
            mockDataService.Setup(m => m.SaveData().Result).Returns(true);
            ICalcService calcService = new CalcService(mockDataService.Object);
            // Act
            int result = await calcService.DoCalcAsync();
            // Assert
            Assert.AreEqual(15, result);
        }
    }
}

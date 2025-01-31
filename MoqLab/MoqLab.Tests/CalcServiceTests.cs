namespace MoqLab.Tests
{
    [TestClass]
    public sealed class CalcServiceTests
    {
        // Es sollen in verschiedenen Tests folgende Sachen getestet werden

        // 1) DoCalc() soll die Summe der Daten zurückgeben, dafür muss IDataService mit Setup gemockt werden
        // 2) DoDynamicCalc() soll die Summe der Daten zurückgeben, dafür muss IDataService mit Setup und Parameter gemockt werden
        // 3) SaveData() soll aufgerufen werden, dafür muss IDataService mit Verify gemockt werden
        // 4) DoCalcAsync() soll getestet werden, dafür muss IDataService mit Setup und Result gemockt werden


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

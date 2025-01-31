namespace MockDemo.Services
{
    public interface ICalcService
    {
        public int DoCalc();
        public Task<int> DoCalcAsync();
        public int DoDynamicCalc(int seed);
    }
}

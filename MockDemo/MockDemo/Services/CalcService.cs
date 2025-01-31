namespace MockDemo.Services
{
    public class CalcService : ICalcService
    {
        private readonly IDataService _dataService;
        public CalcService(IDataService dataService)
        {
            _dataService = dataService;
        }
        public int DoCalc()
        {
            //return 15;
            var data = _dataService.GetData();
            return data.Sum();
        }
        public async Task<int> DoCalcAsync()
        {
            //return 15;
            var data = _dataService.GetData();
            await _dataService.SaveData();
            return data.Sum();
        }

        public int DoDynamicCalc(int seed)
        {
            var data = _dataService.GetDynamicData(seed);
            return data.Sum();
        }
    }
}

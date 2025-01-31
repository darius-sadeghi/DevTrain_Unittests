namespace MoqLab.Services
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
            var data = _dataService.GetData();
            _dataService.SaveData();
            return data.Sum();
        }

        public async Task<int> DoCalcAsync()
        {
            var data = _dataService.GetData();
            await _dataService.SaveDataAsync();
            return data.Sum();
        }

        public int DoDynamicCalc(int seed)
        {
            var data = _dataService.GetDynamicData(seed);
            _dataService.SaveData();
            return data.Sum();
        }
    }
}

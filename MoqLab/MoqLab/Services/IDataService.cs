namespace MoqLab.Services
{
    public interface IDataService
    {
        public List<int> GetData();
        public List<int> GetDynamicData(int seed);
        public void SaveData();
        public Task SaveDataAsync();
    }
}

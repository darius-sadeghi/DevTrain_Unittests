namespace MockDemo.Services
{
    public interface IDataService
    {
        public List<int> GetData();
        public List<int> GetDynamicData(int seed);

        public Task<bool> SaveData();
    }
}

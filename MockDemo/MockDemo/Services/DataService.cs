namespace MockDemo.Services
{
    public class DataService : IDataService
    {
        public List<int> GetData()
        {
            throw new NotImplementedException();
            return new List<int> { 1, 2, 3, 4, 5 };
        }

        public List<int> GetDynamicData(int seed)
        {
            throw new NotImplementedException();
            return Enumerable.Range(1, seed).ToList();
        }

        public async Task<bool> SaveData()
        {
            await Task.Delay(100);
            Console.WriteLine("Save");
            return true;
        }
    }
}

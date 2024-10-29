using Model;

namespace Repository
{
    public class Data
    {
        public Data()
        {

        }

        public async Task LoadAsync()
        {
            Metric1Repository repository = new Metric1Repository();
           await repository.AddAsync(new Metric1 { Id = 1, Name = "Metric 1" });
            await repository.AddAsync(new Metric1 { Id = 2, Name = "Metric 2" });
        }
    }
}
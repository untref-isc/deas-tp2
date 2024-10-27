using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class Metric1Repository
    {
        public Metric1Repository()
        {

        }

        public async Task<List<Metric1>> GetAllAsync()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return await context.Metrics1.ToListAsync();
            }
        }

        public async Task<int> AddAsync(Metric1 metric1)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Metrics1.Add(metric1);
                return await context.SaveChangesAsync();
            }
        }
    }
}
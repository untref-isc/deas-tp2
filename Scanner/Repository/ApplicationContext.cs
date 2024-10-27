using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class ApplicationContext : DbContext
    {
        private string _path;

        public ApplicationContext()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            this._path = Path.Join(path, "blogging.db");
        }

        public DbSet<Metric1> Metrics1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={this._path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
using System.Data.Entity;
using BJAT.Data.Entities;

namespace BJAT.Data.EF
{
    public class AppContext : DbContext
    {
        public AppContext()
            : base("name=AppContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Hand> Hands { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<Mistake> Mistakes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
}
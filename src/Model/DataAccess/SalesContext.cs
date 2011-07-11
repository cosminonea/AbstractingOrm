namespace Model.DataAccess
{
    using System.Data.Entity;

    public class SalesContext : DbContext
    {
        public SalesContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SalesContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Order>();
        }
    }
}
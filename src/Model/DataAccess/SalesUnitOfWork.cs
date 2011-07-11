namespace Model.DataAccess
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Entity;

    using Model.Abstract;

    public class SalesUnitOfWork : ISalesUnitOfWork
    {
            private readonly DbContext context;

        private IRepository<Customer> customers;

        private IRepository<Order> orders;

        #region Constructors and Destructors

            public SalesUnitOfWork(string connectionString)
            {
                context = new SalesContext(connectionString);
            }

            public SalesUnitOfWork()
            {
                context = new SalesContext(ConfigurationManager.AppSettings["ConnectionString"]);
            }

            #endregion

            #region Properties

            public IRepository<Customer> Customers
            {
                get
                {
                    return customers ?? (customers = new SqlRepository<Customer>(context));
                }
            }

        public IRepository<Order> Orders
        {
            get
            {
                return orders ?? (orders = new SqlRepository<Order>(context));
            }
        }

        #endregion

            #region Implemented Interfaces

            #region IDisposable

            public void Dispose()
            {
                context.Dispose();
            }

            #endregion

            #region IUnitOfWork

            public void Commit()
            {
                context.SaveChanges();
            }

            public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
            {
                return context.Database.SqlQuery<T>(sql, parameters);
            }

            public int SqlCommmand(string sql, params object[] parameters)
            {
                return context.Database.ExecuteSqlCommand(sql, parameters);
            }

            #endregion


            #endregion
        }
}

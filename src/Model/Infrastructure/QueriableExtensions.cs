namespace Model.Infrastructure
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public static class QueriableExtensions
    {
        public static IQueryable<T> Include<T>(this IQueryable<T> sequence, string path) where T : class
        {
            var query = sequence as DbQuery<T>;

            if (query != null)
            {
                return query.Include(path);
            }

            return sequence;
        }

    }
}

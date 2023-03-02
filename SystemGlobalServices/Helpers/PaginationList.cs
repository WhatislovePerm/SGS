using System;
namespace SystemGlobalServices.Helpers
{
    public class PaginationList<T> : List<T>
    {
        public PaginationList(List<T> items)
        {
            AddRange(items);
        }

        public static PaginationList<T> ToPaginationdList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PaginationList<T>(items);
        }
    }
}


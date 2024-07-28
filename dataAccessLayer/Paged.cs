using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Access
{
    public class Paged<T> : List<T>
    {
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<T> Items { get; set; }

        public int InitPage { get; private set; }

        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);


        public Paged(List<T> items, int count, int pageNumber, int pageSize)
        {
            Items = items;
            TotalItems = count;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }


        public bool PagesBefore => InitPage > 1;
        public bool PagesAfter => InitPage < TotalPages;

    }
}

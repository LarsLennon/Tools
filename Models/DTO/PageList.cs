using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models.DTO
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int FirstPage { get; private set; }

        public int TotalPages { get; private set; }
        public int LastPage { get; private set; }

        public PageList(List<T> items, int currentPage, int PageSize, int firstPage = 1)
        {
            CurrentPage = currentPage;
            FirstPage = firstPage;
            //result.CurrentPage = PageNumber;
            if (PageSize > 0)
            {
                this.AddRange(items.Skip(PageSize * (CurrentPage - 1)).Take(PageSize).ToList());
                TotalPages = Convert.ToInt32(Math.Ceiling((double)items.Count() / PageSize));
            }
            else
            {
                this.AddRange(items);
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > FirstPage);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < LastPage);
            }
        }
    }
}

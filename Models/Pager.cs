using System;

namespace OnlineCinema.Models
{
    public class Pager
    {
        public Pager(int totalItems, int? page, int pageSize = 5)
        {
            // calculate total, start and end pages
            var totalPages = (int) Math.Ceiling(totalItems / (decimal) pageSize);
            var currentPage = page ?? 1;
            var startPage = currentPage - 3;
            var endPage = currentPage + 2;
            if (startPage <= 0)
            {
                endPage -= startPage - 1;
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 6) startPage = endPage - 5;
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; }
        public int CurrentPage { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int StartPage { get; }
        public int EndPage { get; }
    }
}
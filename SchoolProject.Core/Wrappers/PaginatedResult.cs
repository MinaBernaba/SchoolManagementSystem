﻿namespace SchoolProject.Core.Wrappers
{
    public class PaginatedResult<T>
    {
        public List<T> Data { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public object Meta { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public List<string> Messages { get; set; } = new List<string>();

        public bool Succeeded { get; set; }
        public PaginatedResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int currentPage = 1, int pageSize = 10)
        {
            Data = data;
            CurrentPage = currentPage;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new PaginatedResult<T>(true, data, null, count, page, pageSize);
        }
    }
}

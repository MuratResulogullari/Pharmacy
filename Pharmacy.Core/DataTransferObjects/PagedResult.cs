namespace Pharmacy.Core.DataTransferObjects
{
    public class PagedResult : PagedResult<object>
    {
    }

    public class PagedResult<T>
    {
        public bool Success { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCountOfRecords { get; set; } = 0;
        public int RecordsCountOfPerPage { get; set; } = 0;
        public int PageOfStart { get; set; } = 0;
        public int PageOfEnd { get; set; } = 0;
        public string NextPageUrl { get; set; } = string.Empty;
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

        public int TotalCountOfPages() => (int)(Math.Ceiling(((decimal)TotalCountOfRecords / (decimal)RecordsCountOfPerPage)));
    }
}
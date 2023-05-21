namespace Pharmacy.Core.CriteriaObjects.Bases
{
    public class PagedCriteriaObject : CriteriaObject
    {
        public int CurrentPage { get; set; }
        public int TotalCountOfPages { get; set; }
        public int TotalCountOfRecords { get; set; }
        public int RecordsCountOfPerPage { get; set; }
        public int PageOfStart { get; set; }
        public int PageOfEnd { get; set; }
        public string? SearchKey { get; set; }
        public string? Where { get; set; }
        public object? Parameter { get; set; }
    }
}
namespace Pharmacy.Core.DataTransferObjects
{
    public class RequestResult : RequestResult<object>
    {
    }

    public class RequestResult<TEntity>
    {
        public bool Success { get; set; } = default!;
        public string Message { get; set; }
        public TEntity Result { get; set; }
        public string RedirectUrl { get; set; }
        public object Errors { get; set; }
    }
}
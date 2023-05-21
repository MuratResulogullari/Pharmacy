namespace Pharmacy.Core.DataTransferObjects
{
    public class RequestResult : RequestResult<object>
    {
    }

    public class RequestResult<TEntity>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TEntity Result { get; set; }
        public string RedirectUrl { get; set; }
    }
}
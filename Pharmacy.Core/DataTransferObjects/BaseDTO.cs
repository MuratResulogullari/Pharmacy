namespace Pharmacy.Core.DataTransferObjects
{
    public class BaseDTO : BaseDTO<int>
    {
    }

    public class BaseDTO<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }

        public int LanguageId { get; set; }

        public bool Enable { get; set; }
        public int SortOrder { get; set; }
    }
}
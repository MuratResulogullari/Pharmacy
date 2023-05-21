namespace Pharmacy.Core.DataTransferObjects
{
    public class BaseDTO : BaseDTO<int>
    {
    }

    public class BaseDTO<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }

        public ushort LanguageId { get; set; }

        public bool Enable { get; set; }
        public ushort SortOrder { get; set; }
    }
}
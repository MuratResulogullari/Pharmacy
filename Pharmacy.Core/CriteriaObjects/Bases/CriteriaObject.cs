namespace Pharmacy.Core.CriteriaObjects.Bases
{
    public class CriteriaObject
    {
        public bool GetAllIncludes { get; set; } = default!;
        public string[] Includes { get; set; } = new string[0];
        public int Language { get; set; }
    }
}
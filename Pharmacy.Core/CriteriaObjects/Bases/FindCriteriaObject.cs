using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Core.CriteriaObjects.Bases
{
    public class FindCriteriaObject : CriteriaObject
    {
        public bool FirstOrDefault { get; set; } = default!;
        public bool SingleOrDefault { get; set; } = default!;
    }
}

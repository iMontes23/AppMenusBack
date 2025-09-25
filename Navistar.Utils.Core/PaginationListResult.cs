using System.Collections.Generic;
using System.Linq;

namespace Navistar.Utils.Core
{
    public class PaginationListResult<T>
    {
        public int TotalRowCount { get; set; }
        public List<T> Rows { get; set; }
    }
}

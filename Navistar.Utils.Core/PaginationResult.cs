using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navistar.Utils.Core
{
    public class PaginationResult<T>
    {
        public int TotalRowCount { get; set; }
        public IQueryable<T> Rows { get; set; }
    }
}

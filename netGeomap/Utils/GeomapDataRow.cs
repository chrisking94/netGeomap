using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap.Utils
{
    class GeomapDataRow
    {
        public static double[] ParseNumeric(string rowString)
        {
            var items = rowString.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var nums = items.Select(item => double.Parse(item)).ToArray();

            return nums;
        }
    }
}

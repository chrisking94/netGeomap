using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap.Utils
{
    /// <summary>
    /// 格式化数据为Geomap数据文件标准格式。
    /// </summary>
    static class GeomapDataFormatter
    {
        public static string Format(double value)
        {
            return string.Format("{0:0.0}", value);
        }
    }
}

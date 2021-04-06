using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap
{
    public struct GeomapVector2
    {
        public readonly double x;

        public readonly double y;

        public GeomapVector2(double x, double y) : this()
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// 转换成Geomap数据字符串。
        /// </summary>
        /// <returns></returns>
        public string ToDataString()
        {
            return string.Format("{0:0.0} {0:0.0}", this.x, this.y);
        }

        public override string ToString()
        {
            return $"{x}, {y}";
        }
    }
}

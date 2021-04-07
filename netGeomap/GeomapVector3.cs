using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap
{
    public struct GeomapVector3
    {
        public readonly double x;

        public readonly double y;

        public readonly double z;

        public GeomapVector3(double x, double y, double z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// 转换成Geomap数据字符串。
        /// </summary>
        /// <returns></returns>
        public string ToDataString()
        {
            return string.Format("{0:0.0} {1:0.0} {2:0.0}", this.x, this.y, this.z);
        }

        public override string ToString()
        {
            return $"{x}, {y}, {z}";
        }
    }
}

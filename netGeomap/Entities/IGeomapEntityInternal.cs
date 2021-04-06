using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap.Entities
{
    /// <summary>
    /// 供模块内部使用的接口。
    /// </summary>
    internal interface IGeomapEntityInternal
    {
        /// <summary>
        /// 转换成Geomap数据文本。
        /// </summary>
        /// <returns></returns>
        string ToDataString();
    }
}

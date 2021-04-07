using netGeomap.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap.Entities
{
    /// <summary>
    /// 曲线。
    /// </summary>
    [GeomapEntity(EntityType.GmLine, "3.0", "曲线", MinorType = "Curve")]
    public class GmLineCurve : GmLine
    {
    }
}

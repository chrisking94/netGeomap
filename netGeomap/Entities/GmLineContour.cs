using netGeomap.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap.Entities
{
    /// <summary>
    /// 等高线。
    /// </summary>
    [GeomapEntity(EntityType.GmLine, "3.0", "等值线", MinorType = "Contour"), ]
    public class GmLineContour : GmLine
    {
        public double Height { get; set; }

        public GmLineContour()
        {

        }

        protected override string GetGeneralInfo()
        {
            return $"{this.Vertices.Count} {this.Height}";
        }
    }
}

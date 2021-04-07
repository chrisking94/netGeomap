using netGeomap.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap.Entities
{
    [GeomapEntity(EntityType.GmWell, "3.2", "井位")]
    public class GmWell : IGeomapEntity, IGeomapEntityInternal
    {
        /// <summary>
        /// 井名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 井口坐标。
        /// </summary>
        public GeomapVector2 EntryPoint { get; set; }

        /// <summary>
        /// 井口类型。
        /// </summary>
        public int EntryType { get; set; }

        /// <summary>
        /// 井底类型。
        /// </summary>
        public int BottomType { get; set; }

        /// <summary>
        /// 井底偏移角度。
        /// </summary>
        public double BottomOffsetAngle { get; set; }

        /// <summary>
        /// 井底偏移距离。
        /// </summary>
        public double BottomOffsetDistance { get; set; }

        string IGeomapEntityInternal.ToDataString()
        {
            return $"{this.EntryPoint.ToDataString()} {this.Name} {this.EntryType} {this.BottomType} {this.BottomOffsetAngle} {this.BottomOffsetDistance}";
        }
    }
}

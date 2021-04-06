using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap.Entities
{
    public abstract class GmLine : IGeomapEntity, IGeomapEntityInternal
    {
        /// <summary>
        /// 线的顶点。
        /// </summary>
        public List<GeomapVector3> Vertices { get; }

        public GmLine()
        {
            this.Vertices = new List<GeomapVector3>();
        }

        /// <summary>
        /// 把颈部数据转换成字符串。
        /// </summary>
        /// <returns></returns>
        protected virtual string GetGeneralInfo()
        {
            return $"{this.Vertices.Count}";
        }

        string IGeomapEntityInternal.ToDataString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.GetGeneralInfo());
            var vertices = this.Vertices;
            foreach (var v in vertices)
            {
                sb.AppendLine(v.ToDataString());
            }
            if (vertices.Count > 0) sb.Remove(sb.Length - 2, 2);  // remove last \r\n.

            return sb.ToString();
        }
    }
}

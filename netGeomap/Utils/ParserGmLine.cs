using netGeomap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap.Utils
{
    class ParserGmLine : EntityParser
    {
        protected override IGeomapEntity ParseCore(string[] lines, ref int index, GeomapDataHeader header)
        {
            // 1. 创建实体实例，并读取顶点个数和其它信息。
            GmLine line = null;
            var neckRow = GeomapDataRow.ParseNumeric(lines[index++]);
            var vertexCount = (int)neckRow[0];
            switch (header.MinorType)
            {
                case "Curve":
                    line = new GmLineCurve();
                    break;
                case "Contour":
                    line = new GmLineContour() { Height = neckRow[1] };
                    break;
                default:
                    throw new NotSupportedException($"不支持 '{header.Type}({header.MinorType})' 类型实体。");
            }

            // 2. 读取顶点数据。
            var stopIndex = index + vertexCount;
            for (; index < stopIndex; ++index)
            {
                var row = GeomapDataRow.ParseNumeric(lines[index]);
                var vertex = new GeomapVector3(row[0], row[1], row[2]);
                line.Vertices.Add(vertex);
            }

            return line;
        }
    }
}

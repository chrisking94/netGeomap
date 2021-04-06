using netGeomap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace netGeomap.Utils
{
    class ParserGmWell : EntityParser
    {
        protected override IGeomapEntity ParseCore(string[] lines, ref int index, GeomapDataHeader header)
        {
            var rowStr = lines[index++];
            var chips = Regex.Split(rowStr, @"\s+");
            var well = new GmWell
            {
                EntryPoint = new GeomapVector2(double.Parse(chips[0]), double.Parse(chips[1])),
                Name = chips[2],
                EntryType = int.Parse(chips[3]),
                BottomType = int.Parse(chips[4]),
                BottomOffsetAngle = double.Parse(chips[5]),
                BottomOffsetDistance = double.Parse(chips[6]),
            };

            return well;
        }
    }
}

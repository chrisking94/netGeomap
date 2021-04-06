using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace netGeomap
{
    /// <summary>
    /// Geomap数据头。
    /// </summary>
    internal class GeomapDataHeader
    {
        /// <summary>
        /// 实体的一级类型。
        /// </summary>
        public EntityType Type { get; }

        /// <summary>
        /// 实体的二级类型。例如对于GmLine，有Contour, Curve等二级类型。
        /// </summary>
        public string MinorType { get; }

        /// <summary>
        /// 实体版本号。
        /// </summary>
        public string Version { get; }

        #region Parsing auxiliaries
        private const string HEADER_REGEX = @"(\w+)\s+v([\d\.]+)\(?(\w*)\)?";
        #endregion

        public GeomapDataHeader(EntityType type, string version, string minorType)
        {
            this.Type = type;
            this.Version = version;
            this.MinorType = minorType;
        }

        /// <summary>
        /// 解析实体数据头。例如“GmLine v3.0(Curve)”。
        /// </summary>
        /// <param name="headerLine"></param>
        /// <returns></returns>
        public static GeomapDataHeader Parse(string headerLine)
        {
            var match = Regex.Match(headerLine, HEADER_REGEX);
            if (!match.Success)
            {
                throw new Exception($"无法识别Geomap数据文件头部 '{headerLine}'！");
            }
            var strMajorType = match.Groups[1].Value;
            var version = match.Groups[2].Value;
            var minorType = match.Groups[3].Value;
            if (!Enum.TryParse<EntityType>(strMajorType, out var majorType))
            {
                throw new NotSupportedException($"暂不支持 '{strMajorType}' 类型的实体！");
            }

            return new GeomapDataHeader(majorType, version, minorType);
        }
    }
}

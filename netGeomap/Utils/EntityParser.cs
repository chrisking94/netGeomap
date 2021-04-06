using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap.Utils
{
    /// <summary>
    /// Geomap实体文本数据解析器。
    /// </summary>
    abstract class EntityParser
    {
        private readonly static IReadOnlyDictionary<EntityType, EntityParser> TYPE2PARSER;

        static EntityParser()
        {
            TYPE2PARSER = new Dictionary<EntityType, EntityParser>
            {
                { EntityType.GmLine, new ParserGmLine() },
                { EntityType.GmWell, new ParserGmWell() },
            };
        }

        /// <summary>
        /// 根据实体类型获取实体解析器。
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static EntityParser GetParser(EntityType entityType)
        {
            if (TYPE2PARSER.TryGetValue(entityType, out var parser))
            {
                return parser;
            }
            throw new NotSupportedException($"没有找到 '{entityType}' 类型实体数据的解析器。");
        }

        /// <summary>
        /// 把给定的Geomap数据文本解析成Geomap实体。
        /// </summary>
        /// <param name="geomapDataStr"></param>
        /// <returns></returns>
        public static List<IGeomapEntity> Parse(string geomapDataStr)
        {
            var strArr = geomapDataStr.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var header = GeomapDataHeader.Parse(strArr[0]);
            var parser = GetParser(header.Type);
            var index = 1;
            var entities = new List<IGeomapEntity>();
            while (index < strArr.Length)
            {
                var entity = parser.ParseCore(strArr, ref index, header);
                if (entity == null) break;  // 没有可解析的数据。
                entities.Add(entity);
            }

            return entities;
        }

        /// <summary>
        /// 解析一个实体的数据，并移动<paramref name="index"/>。没有可解析的数据时返回null。
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="index">从DataHeader的下一行开始。</param>
        /// <returns></returns>
        protected abstract IGeomapEntity ParseCore(string[] lines, ref int index, GeomapDataHeader header);
    }
}

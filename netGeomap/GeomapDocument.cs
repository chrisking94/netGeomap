using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netGeomap
{
    /// <summary>
    /// Geomap文档，用于整合管理各种类型的Geomap实体。
    /// </summary>
    public class GeomapDocument
    {
        public IReadOnlyList<IGeomapEntity> Entities => this.entities;

        private List<IGeomapEntity> entities;

        public GeomapDocument()
        {
            this.entities = new List<IGeomapEntity>();
        }

        /// <summary>
        /// 从Geomap数据文件中读取实体。格式请参考<see cref="AddFromString(string)"/>的说明。
        /// </summary>
        /// <param name="filePath"></param>
        public void AddFromFile(string filePath)
        {
            var str = File.ReadAllText(filePath);
            this.AddFromString(str);
        }

        /// <summary>
        /// 从给定Geomap数据字符串中读取实体。
        /// <paramref name="geomapDataStr"/>示例：
        /// <para>GmLine v3.0(Curve)</para>
        /// <para>3</para>
        /// <para>18489157.9 3277691.0 1</para>
        /// <para>18489167.9 3276041.0 1</para>
        /// <para>18489007.9 3275711.0 1</para>
        /// </summary>
        /// <param name="geomapDataStr"></param>
        public void AddFromString(string geomapDataStr)
        {
            var entites = Utils.EntityParser.Parse(geomapDataStr);
            this.AddRange(entites);
        }

        public void Add(IGeomapEntity entity)
        {
            this.entities.Add(entity);
        }

        public void AddRange(IEnumerable<IGeomapEntity> entites)
        {
            foreach (var entity in entites)
            {
                this.Add(entity);
            }
        }
    }
}

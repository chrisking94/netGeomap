using netGeomap.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// 保存成txt文件。
        /// <para>保存程序首先会创建给定文件夹，然后把实体数据按<see cref="Attributes.GeomapEntityAttribute"/>描述分类写入独立的txt文件。</para>
        /// </summary>
        /// <param name="folderPath">保存数据的文件夹。</param>
        public void Save(string folderPath)
        {
            // 1. 创建文件夹；
            Directory.CreateDirectory(folderPath);

            // 2. 写出数据；
            // 2.1 分组；
            var groups = this.entities.GroupBy(e =>
            {
                var type = e.GetType();
                var attr = type.GetCustomAttribute<Attributes.GeomapEntityAttribute>();
                if (attr == null) throw new Exception($"请给 '{type.Name}' 类型实体添加 '{nameof(Attributes.GeomapEntityAttribute)}' 描述。");

                return (attr.Type, attr.MinorType, attr.Version, attr.Name);
            });
            // 2.2 写出；
            var sb = new StringBuilder(1024);
            var folderName = Path.GetFileName(folderPath);
            foreach (var group in groups)
            {
                sb.Clear();
                var meta = group.Key;
                var header = new GeomapDataHeader(meta.Type, meta.Version, meta.MinorType);
                var postfix = meta.Name;

                sb.AppendLine(header.ToDataString());
                foreach (var entity in group)
                {
                    var dataStr = ((IGeomapEntityInternal)entity).ToDataString();
                    sb.AppendLine(dataStr);
                }

                var filePath = $"{folderPath}/{folderName}【{postfix}】.txt";
                File.WriteAllTextAsync(filePath, sb.ToString());  // Write to file.
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace netGeomap.Attributes
{
    /// <summary>
    /// 描述Geomap实体类的元特征。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class GeomapEntityAttribute : Attribute
    {
        /// <summary>
        /// 主类型。
        /// </summary>
        public EntityType Type { get; }

        /// <summary>
        /// 二级类型。
        /// </summary>
        public string MinorType { get; set; }

        /// <summary>
        /// 版本号。
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 中文名称。
        /// </summary>
        public string Name { get; set; }

        public GeomapEntityAttribute(EntityType type, string version, string name)
        {
            Type = type;
            Version = version;
            Name = name;
        }
    }
}

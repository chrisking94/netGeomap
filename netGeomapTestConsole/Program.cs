using System;

namespace netGeomapTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GeomapTest();
        }

        private static void GeomapTest()
        {
            var geomap = new netGeomap.GeomapDocument();
            geomap.AddFromFile(@"G:\tmp\netGeomap\TestData\井位.txt");
            geomap.AddFromFile(@"G:\tmp\netGeomap\TestData\井位.txt");
            geomap.AddFromFile(@"G:\tmp\netGeomap\TestData\等值.txt");
            geomap.AddFromFile(@"G:\tmp\netGeomap\TestData\等值.txt");
            geomap.AddFromFile(@"G:\tmp\netGeomap\TestData\井轨迹线.txt");
            geomap.AddFromFile(@"G:\tmp\netGeomap\TestData\井轨迹线.txt");

            geomap.Save(@"G:\tmp\netGeomap\Output\测试");
        }
    }
}

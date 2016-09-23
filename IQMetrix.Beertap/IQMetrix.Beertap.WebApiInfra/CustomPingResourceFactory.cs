using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Diagnostic;

namespace IQMetrix.Beertap.WebApiInfra
{
    class CustomPingResourceFactory : ICreatePingResource
    {
        readonly Lazy<Tuple<string, DateTime>> _assemblyData = new Lazy<Tuple<string, DateTime>>(() =>
        {
            var assembly = Assembly.GetExecutingAssembly();
            var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            var compileTime = File.GetLastWriteTimeUtc(assembly.Location);
            return Tuple.Create(versionInfo.FileVersion, compileTime);
        });

        public PingResource Create()
        {
            var assemblyData = _assemblyData.Value;
            return new PingResource(applicationVersion: assemblyData.Item1, dbVersion: "", compileTime: assemblyData.Item2);
        }
    }
}

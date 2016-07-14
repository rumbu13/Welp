using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Data
{
    public class ServerContext
    {
        IHostingEnvironment _environment;

        public ServerContext(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        private IEnumerable<string> EnumFiles(string path, string searchPattern)
        {
            foreach (var dir in Directory.EnumerateDirectories(path))
            {
                foreach (var file in Directory.EnumerateFiles(dir, searchPattern))
                    yield return file;
            }

            foreach (var file in Directory.EnumerateFiles(path, searchPattern))
                yield return file;
        }

        public IEnumerable<string> GetFilesFromServerPath(string serverFolder, string searchPattern)
        {
            var path = Path.Combine(_environment.WebRootPath, serverFolder);
            return EnumFiles(path, searchPattern).Select(f => f.Remove(0, path.Length - serverFolder.Length).Replace('\\', '/'));
        }

        
    }
}

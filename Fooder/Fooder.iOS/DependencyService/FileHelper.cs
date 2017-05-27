using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Fooder.iOS.DependencyService;
using Fooder.Interfaces.DependencyService;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace Fooder.iOS.DependencyService
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}

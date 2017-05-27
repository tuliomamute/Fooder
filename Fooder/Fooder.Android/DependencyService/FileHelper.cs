using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Fooder.Droid.DependencyService;
using SQLite.Net.Interop;
using Fooder.Interfaces.DependencyService;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(Fooder.Droid.DependencyService.FileHelper))]
namespace Fooder.Droid.DependencyService
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
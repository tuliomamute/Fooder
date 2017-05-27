using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Runtime.CompilerServices;
using Fooder.Droid.DependencyService;

[assembly: Dependency(typeof(FileHelper))]
namespace Fooder.Droid.DependencyService
{
    public class FileHelper : IFileHelper
    {
    }
}
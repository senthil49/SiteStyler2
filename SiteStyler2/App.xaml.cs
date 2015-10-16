using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace SiteStyler2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void LaunchApplication(object sender, StartupEventArgs e)
        {
            var assemblies = new List<Assembly>() { this.GetType().Assembly };
            Bootstrapper bootstrapper = new Bootstrapper(assemblies);
            bootstrapper.Run();
        }

    }
}

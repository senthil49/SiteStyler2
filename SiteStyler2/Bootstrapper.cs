using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Imaginera.UnityExtensions;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;



using SiteStyler2.Enums;
using SiteStyler2.Extensions;
using SiteStyler2.Views;

namespace SiteStyler2
{
   public class Bootstrapper : UnityBootstrapper
    {
       public IEnumerable<Assembly> assemblies;

       public Bootstrapper(IEnumerable<Assembly> assemblies)
       {
           this.assemblies = assemblies;
       }

       protected override DependencyObject CreateShell()
       {
           var shellView = this.Container.Resolve<ShellView>();
           Application.Current.MainWindow = shellView;
           return shellView;
       }

       protected override void InitializeShell()
       {
           var regionManager = this.Container.Resolve<IRegionManager>();
           ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(this.Container));

           base.InitializeShell();
           Application.Current.MainWindow.Show();

           regionManager.Navigate(RegionNames.ControlsRegion, ViewNames.ControlsView, null);
           regionManager.Navigate(RegionNames.ContentsRegion, ViewNames.ContentsView, null);
       }

       protected override void ConfigureContainer()
       {
           base.ConfigureContainer();
           this.Container.AutoConfigure(this.assemblies);
       }

    }
}

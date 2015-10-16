using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Prism.Regions;



using SiteStyler2.Annotations;

namespace SiteStyler2.ViewModel
{
   public class BaseViewModel :INotifyPropertyChanged, INavigationAware
    {
       public event PropertyChangedEventHandler PropertyChanged;

       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
           var handler = PropertyChanged;
           if (handler != null)
               handler(this, new PropertyChangedEventArgs(propertyName));
       }

       /// <summary>
       /// Called when the implementer has been navigated to.
       /// </summary>
       /// <param name="navigationContext">The navigation context.</param>
       public void OnNavigatedTo(NavigationContext navigationContext)
       {
           
       }

       /// <summary>
       /// Called to determine if this instance can handle the navigation request.
       /// </summary>
       /// <param name="navigationContext">The navigation context.</param>
       /// <returns>
       /// <see langword="true"/> if this instance accepts the navigation request; otherwise, <see langword="false"/>.
       /// </returns>
       public bool IsNavigationTarget(NavigationContext navigationContext)
       {
           return true;
       }

       /// <summary>
       /// Called when the implementer is being navigated away from.
       /// </summary>
       /// <param name="navigationContext">The navigation context.</param>
       public void OnNavigatedFrom(NavigationContext navigationContext)
       {
           this.Dispose();
       }

       private void Dispose()
       {
       }
    }
}

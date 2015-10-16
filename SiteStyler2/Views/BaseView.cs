using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using Microsoft.Practices.Prism.Regions;

namespace SiteStyler2.Views
{
    public class BaseView : UserControl, INavigationAware, INotifyPropertyChanged
    {
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

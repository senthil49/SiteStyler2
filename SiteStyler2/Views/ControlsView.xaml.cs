using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Imaginera.UnityExtensions.Registration;

using SiteStyler2.ViewModel;

namespace SiteStyler2.Views
{
    /// <summary>
    /// Interaction logic for ControlsView
    /// </summary>
    [NamedRegistration(RegistrationName = "ControlsView")]
    [RegisterAsType(RegistrationType = typeof(object))]
    public partial class ControlsView : BaseView, INotifyPropertyChanged
    {
        public ControlsView(IControlsViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}

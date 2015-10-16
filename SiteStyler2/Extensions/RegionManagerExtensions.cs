using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace SiteStyler2.Extensions
{
    public static class RegionManagerExtensions
    {
        /// <summary>
        /// Requests a navigation on the <see cref="IRegionManager"/>
        /// </summary>
        /// <param name="regionManager">
        /// The region manager to extend this method onto
        /// </param>
        /// <param name="region">
        /// The region to host the target of the navigation
        /// </param>
        /// <param name="view">
        /// The view that is the target of the navigation
        /// </param>
        /// <param name="continuation">
        /// The continuation.
        /// </param>
        public static void Navigate(
            this IRegionManager regionManager,
            string region,
            string view,
            Action continuation)
        {
            Navigate(regionManager, region, view, new KeyValuePair<string, object>[0], continuation);
        }

        /// <summary>
        /// Requests a navigation on the <see cref="IRegionManager"/>
        /// </summary>
        /// <param name="regionManager">
        /// The region manager to extend this method onto
        /// </param>
        /// <param name="region">
        /// The region to host the target of the navigation
        /// </param>
        /// <param name="view">
        /// The view that is the target of the navigation
        /// </param>
        /// <param name="query">
        /// The dictionary of key value pairs to form the query string
        /// </param>
        /// <param name="continuation">
        /// The continuation.
        /// </param>
        public static void Navigate(
            this IRegionManager regionManager,
            string region,
            string view,
            IEnumerable<KeyValuePair<string, object>> query,
            Action continuation)
        {
            Debug.Assert(Application.Current.Dispatcher.CheckAccess(), "Navigation must happen from dispatcher thread");

            var logger = ServiceLocator.Current.GetInstance<ILoggerFacade>();
            var uri = new Uri(string.Format("{0}", view), UriKind.Relative);

            Action<NavigationResult> navigationCompleteCallback = x =>
            {
                if (!x.Result.GetValueOrDefault() && x.Error != null)
                {
                    logger.Log(
                        string.Format("Error Navigating to {0}: {1}", uri, x.Error),
                        Category.Exception,
                        Priority.None);
                    Debug.Assert(false, "Navigation failed");
                }

                if (continuation != null && x.Result.GetValueOrDefault())
                {
                    continuation();
                }
            };

            logger.Log(string.Format("Navigating to {0}", uri), Category.Info, Priority.None);

            var parameters = new NavigationParameters();

            foreach (var keyValuePair in query)
            {
                parameters.Add(keyValuePair.Key, keyValuePair.Value);
            }

            regionManager.RequestNavigate(region, uri, navigationCompleteCallback, parameters);
        }
    }

}


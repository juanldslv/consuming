
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;

namespace ejemplo
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        /// 
         public const string PageKeyOrdDetails = "DetailsPage";
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<BooksListViewModel>();
            SimpleIoc.Default.Register<DetailBookViewModel>();
            SimpleIoc.Default.Register<IRequest, Request>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();


        }

        public BooksListViewModel BooksListMainViewModel => SimpleIoc.Default.GetInstance<BooksListViewModel>();
        public DetailBookViewModel DetailBookViewModel => SimpleIoc.Default.GetInstance<DetailBookViewModel>();
        public NavigationService navigationService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigationService>();

            }
        }
        public DetailBookViewModel Details
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<DetailBookViewModel>())
                    SimpleIoc.Default.Register<DetailBookViewModel>();
                return ServiceLocator.Current.GetInstance<DetailBookViewModel>();
            }
        }

    }
}
/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MVVMLightExample1"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace MVVMLightExample1.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// 
    /// ViewModelLocator class is the mediator between your UI and ViewModels that binds the ViewModels to the UI. 
    /// If you want to use your ViewModel as binding source for the UI, you must expose that ViewModel as property in the ViewModelLocator class.
    /// 
    /// In the line 5, we set the IOC container for the application.MVVM Light Toolkit provides a default IOC container. 
    /// IOC container is used for regitering and resolving instances. For more information on IOC click here.
    /// 
    /// In line 7, we register the MainViewModel to the IOC container.
    /// 
    /// In line 8, we register the NotifyUserMethod with the Messenger class. 
    /// So that, when we send the text message with the Messenger class using NotificationMessage it automatically execute the NotifyUserMethod.
    /// 
    /// !!! For using the ViewModelLocator class througout the application, we create an instance of the class in the App.xaml using key "Locator". !!!
    /// 
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        private void NotifyUserMethod(NotificationMessage message)
        {
            MessageBox.Show(message.Notification);
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
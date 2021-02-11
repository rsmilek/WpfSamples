using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMLightExample1.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

/// <summary>
/// This class contains properties that the main View can data bind to.
/// <para>
/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
/// </para>
/// <para>
/// You can also use Blend to data bind with the tool's support.
/// </para>
/// <para>
/// See http://www.galasoft.ch/mvvm
/// </para>
/// </summary>
namespace MVVMLightExample1.ViewModel
{
    /// <summary>
    /// Every viewmodel in MVVM Light Toolkit must inherit from ViewModelBase class. In the below MainViewModel class, 
    /// we inherit our ViewModel from the ViewModelBase class.
    /// 
    /// I have create two properties in this class name EmployeeList and SelectedEmployee. 
    /// EmployeeList is binded to the ItemsSource property of ListBox in line 8 and SelectedEmployee is binded to 
    /// the SelectedItem property of ListBox in line 8.
    /// 
    /// In addition, I have also created two commands name LoadEmployeesCommand and SaveEmployeeCommand.
    /// Both commands are instantiated using RelayCommand in the constructor of the class. 
    /// RelayCommand is a command provided by the MVVM Light Toolkit which purpose is to relay its functionality 
    /// to other objects by invoking delegates.LoadEmployeeCommand is binding to button in line 11 and 
    /// SaveEmployeeCommand is binded to button in line 12. 
    /// LoadEmployeeCommand execute the LoadEmployeesMethod and SaveEmployeesCommand execute the SaveEmployeesMethod when clicked.
    /// 
    /// In Load employees method, we load the employee list from the static method of Employee class. 
    /// Next we notify the UI that EmployeeList property has been changed using the RaisePropertyChanged method.
    /// In the last, we send the notification to the UI to show message box of text "Employee Loaded". 
    /// For this we use the Messenger class of MVVM Light Toolkit.
    /// Messenger class allows object to exchange messages between different classes.
    /// The Default property of Messenger use the default instance of Messenger object provided by the toolkit.
    /// NotificationMessage is also provided by the toolkit and is used for passing a string message to recipient.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> employees;
        private Employee selectedEmployee;

        public ICommand LoadEmployeesCommand { get; private set; }
        public ICommand SaveEmployeesCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            LoadEmployeesCommand = new RelayCommand(LoadEmployeesMethod);
            SaveEmployeesCommand = new RelayCommand(SaveEmployeesMethod);
        }

        public ObservableCollection<Employee> EmployeeList
        {
            get
            {
                return employees;
            }
        }

        public Employee SelectedEmployee
        {
            get
            {
                return selectedEmployee;
            }
            set
            {
                selectedEmployee = value;
                RaisePropertyChanged("SelectedEmployee");
            }
        }

        public void SaveEmployeesMethod()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Saved."));
        }

        private void LoadEmployeesMethod()
        {
            employees = Employee.GetSampleEmployees();
            this.RaisePropertyChanged(() => this.EmployeeList);
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("Employees Loaded."));
        }
    }
}
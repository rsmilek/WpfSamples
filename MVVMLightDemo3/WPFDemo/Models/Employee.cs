using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace WPFDemo.Models
{
    /// <summary>
    /// Every model class in this MVVM Light Toolkit must inherit from ObservableObject.
    /// ObservableObject class is inherit from the INofityPropertyChanged interface. 
    /// This interface provides PropertyChanged event handler that notify clients that a property value has changed. 
    /// ObservableObject use that event in RaisePropertyChanged method to notify other classes. 
    /// In addition, ObservableObject class also provides a Set method to set the property and raise the PropertyChanged event automatically.
    /// Set method takes property name, reference to the private variable and the new value
    /// </summary>
    [DoNotNotify] // Fody.PropertyChanged is disabled
    public class Employee : ObservableObject
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private int _age;
        private decimal _salary;

        public int ID
        {
            get => _id;
            set => Set<int>(() => ID, ref _id, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => Set<string>(() => FirstName, ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => Set<string>(() => LastName, ref _lastName, value);
        }

        public int Age
        {
            get => _age;
            set => Set<int>(() => Age, ref _age, value);
        }

        public decimal Salary
        {
            get => _salary;
            set => Set<decimal>(() => Salary, ref _salary, value);
        }
    }
}

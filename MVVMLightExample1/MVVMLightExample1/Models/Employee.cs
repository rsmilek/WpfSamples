using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLightExample1.Models
{
    /// <summary>
    /// Every model class in this MVVM Light Toolkit must inherit from ObservableObject. 
    /// ObservableObject class is inherit from the INofityPropertyChanged interface. 
    /// This interface provides PropertyChanged event handler that notifiy clients that a property value has changed. 
    /// ObservableObject use that event in RaisePropertyChanged method to notify other classes. 
    /// In addition, ObservableObject class also provides a Set method to set the property and raise the PropertyChanged event automatically. 
    /// Set method takes property name, reference to the private variable and the new value. Below I have shown an example of Employee class.
    /// </summary>
    public class Employee : ObservableObject
    {
        private int id;
        private string name;
        private int age;
        private decimal salary;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                Set<int>(() => this.ID, ref id, value);
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                Set<string>(() => this.Name, ref name, value);
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                Set<int>(() => this.Age, ref age, value);
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                Set<decimal>(() => this.Salary, ref salary, value);
            }
        }

        public static ObservableCollection<Employee> GetSampleEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            for (int i = 0; i < 30; ++i)
            {
                employees.Add(new Employee
                {
                    ID = i + 1,
                    Name = "Name " + (i + 1).ToString(),
                    Age = 20 + i,
                    Salary = 20000 + (i * 10)
                });
            }
            return employees;
        }
    }
}

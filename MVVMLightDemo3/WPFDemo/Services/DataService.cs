using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WPFDemo.Abstractions;
using WPFDemo.Models;

namespace WPFDemo.Services
{
    public class DataService : IDataService
    {
        public ObservableCollection<Employee> GetSampleEmployees()
        {
            var employees = new ObservableCollection<Employee>();
            for (int i = 0; i < 10; ++i)
            {
                employees.Add(
                    new Employee()
                    {
                        ID = i + 1,
                        FirstName = $"First{i+1}",
                        LastName = $"Last{i+1}",
                        Age = 20 + i,
                        Salary = 20000 + (i * 10)
                    }
                );
            }
            return employees;
        }
    }
}

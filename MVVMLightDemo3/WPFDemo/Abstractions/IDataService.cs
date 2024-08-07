using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WPFDemo.Models;

namespace WPFDemo.Abstractions
{
    public interface IDataService
    {
        ObservableCollection<Employee> GetSampleEmployees();
    }
}

using GalaSoft.MvvmLight;
using System;

namespace WPFDemo.ViewModel
{
    // This VM uses Fody
    public class ValueUnitViewModel : ViewModelBase
    {
        public String Label { get; set; }
        public String Value { get; set; }
        public String Unit { get; set; }

        public ValueUnitViewModel(
            string label,
            string value,
            string unit)
        { 
            Label = label;
            Value = value;
            Unit = unit;
        }

        [Obsolete("Design-time ctor only!")]
        public ValueUnitViewModel()
        {
            Label = "Voltage";
            Value = "1000";
            Unit = "V";
        }
    }
}

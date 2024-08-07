using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace WPFDemo.ViewModel
{
    // This VM uses Fody
    public class NodeFodyViewModel : ObservableObject
    {
        public bool IsExpanded { get; set; }

        public string Name { get; set; }

        public ObservableCollection<NodeFodyViewModel> InnerItems { get; set; } = new ObservableCollection<NodeFodyViewModel>();
    }
}

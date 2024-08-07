using GalaSoft.MvvmLight;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace WPFDemo.ViewModel
{
    [DoNotNotify] // Fody.PropertyChanged is disabled
    public class NodeMvvmViewModel : ObservableObject
    {
        private bool _isExpanded;

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    RaisePropertyChanged(() => IsExpanded);
                }
            }
        }

        public string Name { get; set; }

        public ObservableCollection<NodeMvvmViewModel> InnerItems { get; set; } = new ObservableCollection<NodeMvvmViewModel>();
    }
}

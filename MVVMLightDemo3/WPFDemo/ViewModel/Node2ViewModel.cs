using GalaSoft.MvvmLight;
using PropertyChanged;

namespace WPFDemo.ViewModel
{
    [DoNotNotify] // Fody.PropertyChanged is disabled
    public class Node2ViewModel : ObservableObject
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
    }
}

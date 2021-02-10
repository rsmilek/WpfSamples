using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight; //For mvvmlight
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging; //for class Messenger
using MVVMLightHelloWorld.Messages;

namespace MVVMLightHelloWorld.ViewModel
{

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
    public class SenderViewModel : ViewModelBase
    {
        private String _textBoxText;
        public RelayCommand OnClickCommand { get; set; }

        public SenderViewModel()
        {            
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            OnClickCommand = new RelayCommand(OnClickCommandAction, null);
        }

        public string TextBoxText
        {
            get { return _textBoxText; }

            set
            {
                _textBoxText = value;
                RaisePropertyChanged("TextBoxText");
            }
        }

        private void OnClickCommandAction()
        {
            var viewModelMessage = new ViewModelMessage() { Text = TextBoxText };
            Messenger.Default.Send(viewModelMessage);
        }
    }
}

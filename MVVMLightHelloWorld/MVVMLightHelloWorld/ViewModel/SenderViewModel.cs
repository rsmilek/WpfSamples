using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMLightHelloWorld.Messages;

namespace MVVMLightHelloWorld.ViewModel
{
    public class SenderViewModel : ViewModelBase
    {
        private String _textBoxText;
        public ICommand OnClickCommand { get; private set; }

        public SenderViewModel()
        {            
            OnClickCommand = new RelayCommand(OnClickCommandAction, null);
        }

        public string TextBoxText
        {
            get 
            { 
                return _textBoxText; 
            }
            set
            {
                _textBoxText = value;
                RaisePropertyChanged("TextBoxText");
            }
        }

        private void OnClickCommandAction()
        {
            var viewModelMessage = new ViewModelMessage() { Text = TextBoxText };
            //Messenger.Default.Send(viewModelMessage);
            Messenger.Default.Send<ViewModelMessage>(viewModelMessage);
        }
    }
}

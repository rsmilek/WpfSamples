using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MVVMLightHelloWorld.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLightHelloWorld.ViewModel
{
    public class ReceiverViewModel: ViewModelBase
    {
        private string _contentText;

        public ReceiverViewModel()
        {
            Messenger.Default.Register<ViewModelMessage>(this, OnReceiveMessageAction);
        }

        public string ContentText
        {
            get { return _contentText; }
            set
            {
                _contentText = value;
                RaisePropertyChanged("ContentText");
            }
        }

        private void OnReceiveMessageAction(ViewModelMessage obj)
        {
            ContentText = obj.Text;
        }
    }
}

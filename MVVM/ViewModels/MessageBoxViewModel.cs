using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVM.ViewModels
{
    public class MessageBoxViewModel : BindableBase, IDialogAware
    {
        public MessageBoxViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }

        public string Title => throw new NotImplementedException();

        public event Action<IDialogResult> RequestClose;

        private string _message = string.Empty;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand OKButton
        {
            get;
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>(nameof(Message));
        }

        private void OKButtonExecute()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }
    }
}

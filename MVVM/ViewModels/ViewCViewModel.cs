using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Services.Dialogs;

namespace MVVM.ViewModels
{
    public class ViewCViewModel : BindableBase, IDialogAware
    {
        public ViewCViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }
        private string _viewCTextBox = "XXX";

        public event Action<IDialogResult> RequestClose;

        public string ViewCTextBox
        {
            get { return _viewCTextBox; }
            set { SetProperty(ref _viewCTextBox, value); }
        }

        public string Title => "ViewCのタイトル";

        public DelegateCommand OKButton { get; }
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            ViewCTextBox = parameters.GetValue<string>(nameof(ViewCTextBox));
        }

       
        public void OKButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewCTextBox), ViewCTextBox);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK,p));
        }
    }
}

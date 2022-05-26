using Prism.Mvvm;
using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using MVVM.Views;
using System;

namespace MVVM.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            SystemDateUpdateButton = new DelegateCommand(SystemDateUpdateButtonExecute);
            ShowViewAButton = new DelegateCommand(ShowViewAButtonExecute);
            ShowViewBButton = new DelegateCommand(ShowViewBButtonExecute);
            ShowViewCButton = new DelegateCommand(ShowViewCButtonExecute);
        }
        private string _systemDataLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        public string SystemDataLabel
        {
            get { return _systemDataLabel; }
            set { SetProperty(ref _systemDataLabel, value); }
        }

        public DelegateCommand SystemDateUpdateButton { get;}
        public DelegateCommand ShowViewAButton { get;}
        public DelegateCommand ShowViewBButton { get;}
        public DelegateCommand ShowViewCButton { get; }
        private void SystemDateUpdateButtonExecute()
        {
            SystemDataLabel = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void ShowViewAButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }

        private void ShowViewBButtonExecute()
        {
            var p = new NavigationParameters();
            p.Add(nameof(ViewBViewModel.MyLabel), SystemDataLabel);
            _regionManager.RequestNavigate("ContentRegion", nameof(ViewB), p);
        }
        private void ShowViewCButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewCViewModel.ViewCTextBox), SystemDataLabel);
            _dialogService.ShowDialog(nameof(ViewC), p, ViewCClose);
        }
        
        private void ViewCClose(IDialogResult dialogResult)
        {
            if(dialogResult.Result == ButtonResult.OK)
            {
                SystemDataLabel = dialogResult.Parameters.GetValue<string>(nameof(ViewCViewModel.ViewCTextBox));
            }
        }
    }
}

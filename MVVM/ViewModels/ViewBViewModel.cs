using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVM.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        public ViewBViewModel()
        {

        }

        private string _myLabel = string.Empty;
        public string MyLabel
        {
            get { return _myLabel; }
            set { SetProperty(ref _myLabel, value); }
        }
        //ナビゲーションが移ったときに実行される。パラメータを受け取りたいときはnavigationContextより取得
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            MyLabel = navigationContext.Parameters.GetValue<string>(nameof(MyLabel));
        }
        //インスタンスを使いまわすかどうか。
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        //ナビゲーションが他に移るときに実行。終了処理が記述
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}

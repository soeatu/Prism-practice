using MVVM.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using MVVM.ViewModels;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterDialog<ViewC, ViewCViewModel>();
        }
    }
}

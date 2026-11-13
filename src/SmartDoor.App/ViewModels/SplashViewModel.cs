using CommunityToolkit.Mvvm.ComponentModel;
using SmartDoor.App.Services;
using System.Threading.Tasks;

namespace SmartDoor.App.ViewModels;

public partial class SplashViewModel : ObservableObject
{
    public SplashViewModel(NavigationService nav)
    {
        Task.Delay(4000).ContinueWith(_ =>
            App.Current.Dispatcher.Invoke(() => nav.NavigateTo<LoginViewModel>()));
    }
}
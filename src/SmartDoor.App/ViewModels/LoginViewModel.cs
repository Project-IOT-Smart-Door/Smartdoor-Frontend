using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartDoor.App.Services;

namespace SmartDoor.App.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly NavigationService _nav;

    public LoginViewModel(NavigationService nav) => _nav = nav;

    [RelayCommand]
    private void GoToAdminLogin() => _nav.NavigateTo<AdminLoginViewModel>();

    [RelayCommand]
    private void GoToUserLogin() => _nav.NavigateTo<UserLoginViewModel>();
}
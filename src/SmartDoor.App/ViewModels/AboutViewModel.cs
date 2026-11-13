using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartDoor.App.Services;

namespace SmartDoor.App.ViewModels;

public partial class AboutViewModel : ObservableObject
{
    private readonly NavigationService _nav;

    public AboutViewModel(NavigationService nav) => _nav = nav;

    [RelayCommand]
    private void GoBack()
    {
        // Jika Admin, kembali ke Dashboard Admin. Jika User, ke Dashboard User.
        if (CurrentSession.Role == "Admin")
            _nav.NavigateTo<AdminDashboardViewModel>();
        else
            _nav.NavigateTo<UserDashboardViewModel>();
    }
}
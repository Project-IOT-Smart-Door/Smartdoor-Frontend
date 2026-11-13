using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartDoor.App.Services;

namespace SmartDoor.App.ViewModels;

public partial class ProfileViewModel : ObservableObject
{
    private readonly NavigationService _nav;

    [ObservableProperty] private string _nama = "";
    [ObservableProperty] private string _username = "";
    [ObservableProperty] private string _role = "";
    [ObservableProperty] private string _noHP = "081234567890";
    [ObservableProperty] private string _email = "user@smartdoor.id";
    
    public ProfileViewModel(NavigationService nav)
    {
        _nav = nav;
        Nama = CurrentSession.NamaLengkap;
        Username = CurrentSession.Username;
        Role = CurrentSession.Role;
    }

    [RelayCommand]
    private void GoBack() => _nav.NavigateTo<UserDashboardViewModel>();
}
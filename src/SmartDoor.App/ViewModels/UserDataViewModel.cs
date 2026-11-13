using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartDoor.App.Services;
using System.Collections.ObjectModel;

namespace SmartDoor.App.ViewModels;

public partial class UserDataViewModel : ObservableObject
{
    private readonly NavigationService _nav;
    public ObservableCollection<UserItem> Users { get; } = new();

    public UserDataViewModel(NavigationService nav)
    {
        _nav = nav;
        Users.Add(new UserItem { No = 1, Nama = "Bayu Putra", NIM = "12345678" });
        Users.Add(new UserItem { No = 2, Nama = "Siti Aminah", NIM = "87654321" });
    }

    [RelayCommand]
    private void GoBack() => _nav.NavigateTo<AdminDashboardViewModel>();
}
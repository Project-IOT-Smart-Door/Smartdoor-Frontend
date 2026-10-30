using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartDoor.App.Services;
using System;
using System.Collections.ObjectModel;

namespace SmartDoor.App.ViewModels;

public partial class AdminDashboardViewModel : ObservableObject
{
    private readonly NavigationService _nav;
    private readonly ThemeService _theme;

    [ObservableProperty] private string _adminName = "Administrator";
    [ObservableProperty] private int _totalUsers = 48;
    [ObservableProperty] private int _totalAccess = 1245;
    [ObservableProperty] private int _totalDenied = 12;
    [ObservableProperty] private string _doorStatus = "🔒 TERKUNCI";

    public ObservableCollection<UserItem> Users { get; } = new();
    public ObservableCollection<LogItem> Logs { get; } = new();

    public AdminDashboardViewModel(NavigationService nav, ThemeService theme)
    {
        _nav = nav;
        _theme = theme;

        AdminName = CurrentSession.NamaLengkap;

        Users.Add(new UserItem { No = 1, Nama = "Bayu Putra", NIM = "12345678" });
        Users.Add(new UserItem { No = 2, Nama = "Siti Aminah", NIM = "87654321" });

        Logs.Add(new LogItem { Waktu = "10:45:12", UID = "A1B2C3D4", Status = "✅ BERHASIL" });
        Logs.Add(new LogItem { Waktu = "10:42:05", UID = "E5F6G7H8", Status = "✅ BERHASIL" });
        Logs.Add(new LogItem { Waktu = "10:40:30", UID = "XX999988", Status = "❌ DITOLAK" });
    }

    [RelayCommand]
    private void OpenDoorManual()
    {
        DoorStatus = "🔓 TERBUKA";
        System.Threading.Tasks.Task.Delay(3000).ContinueWith(_ =>
        {
            App.Current.Dispatcher.Invoke(() => DoorStatus = "🔒 TERKUNCI");
        });
    }

    // === THEME COMMANDS ===
    [RelayCommand] private void ThemeLight() => _theme.ApplyLight();
    [RelayCommand] private void ThemeDark() => _theme.ApplyDark();
    [RelayCommand] private void ThemeCustom() => _theme.ApplyCustom();

    // === NAVIGASI ===
    [RelayCommand] private void Logout() => _nav.NavigateTo<LoginViewModel>();

    // TAMBAHAN BARU: Navigasi ke Data Pengguna
    [RelayCommand] private void GoToUserData() => _nav.NavigateTo<UserDataViewModel>();

    [RelayCommand] private void GoToDiagram() => _nav.NavigateTo<MonitoringViewModel>();
    [RelayCommand] private void GoToBlockCard() => _nav.NavigateTo<CardBlockViewModel>();
    [RelayCommand] private void GoToRegisterCard() => _nav.NavigateTo<RegisterCardViewModel>();
    [RelayCommand] private void GoToAbout() => _nav.NavigateTo<AboutViewModel>();
}

// Model Tabel
public class UserItem
{
    public int No { get; set; }
    public string Nama { get; set; } = "";
    public string NIM { get; set; } = "";
}

public class LogItem
{
    public string Waktu { get; set; } = "";
    public string UID { get; set; } = "";
    public string Status { get; set; } = "";
}
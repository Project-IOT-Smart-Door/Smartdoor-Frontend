using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartDoor.App.Services;
using System.Collections.ObjectModel;

namespace SmartDoor.App.ViewModels;

public partial class UserDashboardViewModel : ObservableObject
{
    private readonly NavigationService _nav;
    private readonly ThemeService _theme; // TAMBAHAN: Untuk ganti tema

    [ObservableProperty] private string _userName = "Bayu Putra";
    [ObservableProperty] private string _cardUID = "A1B2C3D4";
    [ObservableProperty] private string _cardStatus = "AKTIF";
    [ObservableProperty] private string _registerDate = "16 Okt 2026";
    [ObservableProperty] private int _totalAksesBulanIni = 12;

    public ObservableCollection<LogItem> AccessHistory { get; } = new();

    // TAMBAHAN: ThemeService dimasukkan ke dalam constructor
    public UserDashboardViewModel(NavigationService nav, ThemeService theme)
    {
        _nav = nav;
        _theme = theme;

        UserName = CurrentSession.NamaLengkap; // Ambil nama dari sesi login

        AccessHistory.Add(new LogItem { Waktu = "Hari ini, 09:15", Status = "✅ Berhasil" });
        AccessHistory.Add(new LogItem { Waktu = "Kemarin, 17:30", Status = "✅ Berhasil" });
        AccessHistory.Add(new LogItem { Waktu = "Kemarin, 08:00", Status = "✅ Berhasil" });
        AccessHistory.Add(new LogItem { Waktu = "20 Okt 2026, 19:00", Status = "❌ Ditolak" });
    }

    [RelayCommand] private void ChangeCard() { }
    [RelayCommand] private void DeactivateCard() { }
    [RelayCommand] private void Logout() => _nav.NavigateTo<LoginViewModel>();

    // === THEME COMMANDS (TAMBAHAN) ===
    [RelayCommand] private void ThemeLight() => _theme.ApplyLight();
    [RelayCommand] private void ThemeDark() => _theme.ApplyDark();
    [RelayCommand] private void ThemeCustom() => _theme.ApplyCustom();

    // === NAVIGASI SIDEBAR ===
    [RelayCommand] private void GoToDiagram() => _nav.NavigateTo<MonitoringViewModel>();
    [RelayCommand] private void GoToContact() => _nav.NavigateTo<ContactViewModel>();
    [RelayCommand] private void GoToRegisterCard() => _nav.NavigateTo<RegisterCardViewModel>();
    [RelayCommand] private void GoToAbout() => _nav.NavigateTo<AboutViewModel>();

    // TAMBAHAN: Navigasi ke halaman Profil
    [RelayCommand] private void GoToProfile() => _nav.NavigateTo<ProfileViewModel>();
}
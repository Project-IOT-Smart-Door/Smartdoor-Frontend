using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SmartDoor.App.Services;
using System.Threading.Tasks;

namespace SmartDoor.App.ViewModels;

public partial class UserLoginViewModel : ObservableObject
{
    private readonly NavigationService _nav;

    [ObservableProperty] private string _username = "";
    [ObservableProperty] private string _password = "";
    [ObservableProperty] private string _errorMessage = "";

    public UserLoginViewModel(NavigationService nav) => _nav = nav;

    [RelayCommand]
    private async Task LoginAsync()
    {
        ErrorMessage = "";
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Username dan Password wajib diisi!";
            return;
        }

        await Task.Delay(500);

        if (Username.ToLower() == "user" && Password == "user123")
        {
            // ==========================================
            // TAMBAHAN PENTING: SIMPAN SESI USER
            // ==========================================
            CurrentSession.Username = Username;
            CurrentSession.NamaLengkap = "Bayu Putra"; // Bisa diganti dengan data dari database nanti
            CurrentSession.Role = "User";
            CurrentSession.CardUID = "A1B2C3D4"; // Dummy UID untuk testing

            // Pindah ke Dashboard User
            _nav.NavigateTo<UserDashboardViewModel>();
        }
        else
        {
            ErrorMessage = "Username atau Password salah! (Gunakan: user / user123)";
        }
    }

    [RelayCommand]
    private void GoBack() => _nav.NavigateTo<LoginViewModel>();

    [RelayCommand]
    private void GoToRegister()
    {
        var vm = App.Services.GetRequiredService<RegisterViewModel>();
        vm.IsAdminMode = false;
        _nav.NavigateTo(vm);
    }

    [RelayCommand]
    private void ForgotPassword()
    {
        SmartDoor.App.Views.Components.NotificationDialog.ShowInfo(
            "Lupa Password User",
            "Silakan hubungi Admin di menu 'Hubungi Admin' atau datang ke ruang IT untuk mereset password Anda.");
    }
}
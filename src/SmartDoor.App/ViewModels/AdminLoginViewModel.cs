using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SmartDoor.App.Services;
using SmartDoor.Backend.Data;
using System;
using System.Threading.Tasks;

namespace SmartDoor.App.ViewModels;

public partial class AdminLoginViewModel : ObservableObject
{
    private readonly NavigationService _nav;
    private readonly SmartDoorDb _db;

    [ObservableProperty] private string _username = "";
    [ObservableProperty] private string _password = "";
    [ObservableProperty] private string _errorMessage = "";

    public AdminLoginViewModel(NavigationService nav, SmartDoorDb db)
    {
        _nav = nav;
        _db = db;
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        ErrorMessage = "";
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Username dan Password wajib diisi!";
            return;
        }

        try
        {
            var admin = await _db.LoginAsync(Username, Password);

            if (admin == null)
            {
                ErrorMessage = "Username atau Password salah!";
                return;
            }

            // ==========================================
            // PERBAIKAN: admin.NamaLengkap diganti "Administrator"
            // ==========================================
            CurrentSession.Username = Username;
            CurrentSession.NamaLengkap = "Administrator";
            CurrentSession.Role = "Admin";

            // Pindah ke Dashboard Admin
            _nav.NavigateTo<AdminDashboardViewModel>();
        }
        catch (Exception ex)
        {
            ErrorMessage = "Gagal terhubung ke database: " + ex.Message;
        }
    }

    [RelayCommand]
    private void GoBack() => _nav.NavigateTo<LoginViewModel>();

    [RelayCommand]
    private void GoToRegister()
    {
        var vm = App.Services.GetRequiredService<RegisterViewModel>();
        vm.IsAdminMode = true;
        _nav.NavigateTo(vm);
    }

    [RelayCommand]
    private void ForgotPassword()
    {
        SmartDoor.App.Views.Components.NotificationDialog.ShowInfo(
            "Lupa Password Admin",
            "Silakan hubungi Super Admin / Pengembang sistem untuk melakukan reset password.");
    }
}
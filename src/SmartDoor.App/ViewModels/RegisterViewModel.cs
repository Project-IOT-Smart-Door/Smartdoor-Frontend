using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartDoor.App.Services;
using System.Threading.Tasks;

namespace SmartDoor.App.ViewModels;

public partial class RegisterViewModel : ObservableObject
{
    private readonly NavigationService _nav;

    // Penanda apakah pendaftaran ini dibuka dari Admin atau User
    public bool IsAdminMode { get; set; } = false;

    [ObservableProperty] private string _namaLengkap = "";
    [ObservableProperty] private string _gender = "Laki-laki";
    [ObservableProperty] private string _umur = "";
    [ObservableProperty] private string _nim = "";
    [ObservableProperty] private string _noHP = "";
    [ObservableProperty] private string _email = "";
    [ObservableProperty] private string _username = "";
    [ObservableProperty] private string _password = "";
    [ObservableProperty] private string _konfirmasiPassword = "";
    [ObservableProperty] private bool _isAgreed = false;
    [ObservableProperty] private string _message = "";

    public RegisterViewModel(NavigationService nav)
    {
        _nav = nav;
    }

    [RelayCommand]
    private async Task RegisterAsync()
    {
        Message = "";

        if (string.IsNullOrWhiteSpace(NamaLengkap) || string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            Message = "Nama, Username, dan Password wajib diisi!";
            return;
        }

        if (Password != KonfirmasiPassword)
        {
            Message = "Password dan Konfirmasi tidak cocok!";
            return;
        }

        if (!IsAgreed)
        {
            Message = "Anda harus menyetujui Syarat & Ketentuan!";
            return;
        }

        // Simulasi daftar sukses
        await Task.Delay(500);
        SmartDoor.App.Views.Components.NotificationDialog.ShowSuccess("REGISTRASI BERHASIL", "Akun Anda berhasil dibuat. Silakan login kembali.");

        // Cek mode, kembalikan ke halaman yang sesuai
        if (IsAdminMode)
            _nav.NavigateTo<AdminLoginViewModel>();
        else
            _nav.NavigateTo<UserLoginViewModel>();
    }

    [RelayCommand]
    private void GoBack()
    {
        // Cek mode, kembalikan ke halaman yang sesuai
        if (IsAdminMode)
            _nav.NavigateTo<AdminLoginViewModel>();
        else
            _nav.NavigateTo<UserLoginViewModel>();
    }
}
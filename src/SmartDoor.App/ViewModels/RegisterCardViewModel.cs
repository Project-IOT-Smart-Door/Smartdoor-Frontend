using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartDoor.App.Services;
using System.Threading.Tasks;

namespace SmartDoor.App.ViewModels;

public partial class RegisterCardViewModel : ObservableObject
{
    private readonly NavigationService _nav;

    [ObservableProperty] private string _detectedUID = "";
    [ObservableProperty] private string _statusMessage = "Tekan MULAI SCAN untuk mendeteksi kartu.";
    [ObservableProperty] private bool _canSave = false;

    public RegisterCardViewModel(NavigationService nav)
    {
        _nav = nav;
    }

    [RelayCommand]
    private void GoBack()
    {
        // Kembali ke Dashboard yang sesuai
        if (CurrentSession.Role == "Admin")
            _nav.NavigateTo<AdminDashboardViewModel>();
        else
            _nav.NavigateTo<UserDashboardViewModel>();
    }

    [RelayCommand]
    private async Task StartScanAsync()
    {
        DetectedUID = "";
        CanSave = false;
        StatusMessage = "Menunggu kartu ditempelkan ke reader...";

        // Simulasi jeda saat Arduino membaca kartu (2 detik)
        await Task.Delay(2000);

        // Simulasi UID yang terbaca dari Arduino
        DetectedUID = "A1B2C3D4";
        StatusMessage = "✅ Kartu terdeteksi! Silakan klik SIMPAN KARTU.";
        CanSave = true;
    }

    [RelayCommand]
    private async Task SaveCardAsync()
    {
        if (string.IsNullOrEmpty(DetectedUID)) return;

        StatusMessage = "Menyimpan ke database...";
        CanSave = false;

        // Simulasi proses simpan ke database (1 detik)
        await Task.Delay(1000);

        // Tampilkan notifikasi sukses (menggunakan komponen yang sudah kita buat)
        SmartDoor.App.Views.Components.NotificationDialog.ShowSuccess(
            "BERHASIL DISIMPAN",
            $"Kartu dengan UID {DetectedUID} berhasil didaftarkan ke sistem.");

        // Setelah sukses, kembalikan ke dashboard
        GoBack();
    }
}
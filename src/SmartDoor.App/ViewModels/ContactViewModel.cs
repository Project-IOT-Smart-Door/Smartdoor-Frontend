using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartDoor.App.Services;

namespace SmartDoor.App.ViewModels;

public partial class ContactViewModel : ObservableObject
{
    private readonly NavigationService _nav;

    public ContactViewModel(NavigationService nav) => _nav = nav;

    [RelayCommand]
    private void GoBack()
    {
        // Jika Admin, kembali ke Dashboard Admin. Jika User, ke Dashboard User.
        if (CurrentSession.Role == "Admin")
            _nav.NavigateTo<AdminDashboardViewModel>();
        else
            _nav.NavigateTo<UserDashboardViewModel>();
    }

    // TAMBAHAN: Command untuk tombol Kirim Laporan (Simulasi)
    [RelayCommand]
    private void KirimLaporan()
    {
        SmartDoor.App.Views.Components.NotificationDialog.ShowSuccess(
            "LAPORAN TERKIRIM",
            "Pesan Anda telah dikirim ke Admin. Mohon tunggu balasan melalui kontak yang tertera.");
    }
}
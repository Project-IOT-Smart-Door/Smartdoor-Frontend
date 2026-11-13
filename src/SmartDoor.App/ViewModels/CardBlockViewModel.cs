using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SmartDoor.App.Services;

namespace SmartDoor.App.ViewModels;

public partial class CardBlockViewModel : ObservableObject
{
    private readonly NavigationService _nav;

    public CardBlockViewModel(NavigationService nav) => _nav = nav;

    [RelayCommand]
    private void GoBack()
    {
        // Cek Role, kembali ke Dashboard yang sesuai
        if (CurrentSession.Role == "Admin")
            _nav.NavigateTo<AdminDashboardViewModel>();
        else
            _nav.NavigateTo<UserDashboardViewModel>();
    }

    // TAMBAHAN: Command simulasi untuk tombol blokir (di UI nanti)
    [RelayCommand]
    private void BlokirKartu()
    {
        SmartDoor.App.Views.Components.NotificationDialog.ShowSuccess(
            "KARTU DIBLOKIR",
            "Kartu dengan UID tersebut berhasil diblokir dari sistem.");
    }
}
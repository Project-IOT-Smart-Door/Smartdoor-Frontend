using System.Windows.Controls;
using SmartDoor.App.ViewModels;

namespace SmartDoor.App.Views;

public partial class RegisterView : UserControl
{
    public RegisterView() => InitializeComponent();

    private void Pwd1_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataContext is RegisterViewModel vm) vm.Password = Pwd1.Password;
    }

    private void Pwd2_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataContext is RegisterViewModel vm) vm.KonfirmasiPassword = Pwd2.Password;
    }
}

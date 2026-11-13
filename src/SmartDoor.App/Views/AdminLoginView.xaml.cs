using System.Windows.Controls;
using SmartDoor.App.ViewModels;

namespace SmartDoor.App.Views;

public partial class AdminLoginView : UserControl
{
    public AdminLoginView() => InitializeComponent();

    private void PwdBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataContext is AdminLoginViewModel vm) vm.Password = PwdBox.Password;
    }
}
using System.Windows.Controls;
using SmartDoor.App.ViewModels;

namespace SmartDoor.App.Views;

public partial class UserLoginView : UserControl
{
    public UserLoginView() => InitializeComponent();

    private void PwdBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataContext is UserLoginViewModel vm) vm.Password = PwdBox.Password;
    }
}
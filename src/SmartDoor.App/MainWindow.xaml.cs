using SmartDoor.App.Services;
using SmartDoor.App.ViewModels;
using System.Windows;

namespace SmartDoor.App;

public partial class MainWindow : Window
{
    public MainWindow(NavigationService nav)
    {
        InitializeComponent();
        DataContext = nav;
        nav.NavigateTo<SplashViewModel>();
    }
}
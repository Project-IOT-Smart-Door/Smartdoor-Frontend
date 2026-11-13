using Microsoft.Extensions.DependencyInjection;
using SmartDoor.App.Services;
using SmartDoor.App.ViewModels;
using SmartDoor.Backend.Data;
using SmartDoor.Backend.Services;
using System;
using System.Windows;

namespace SmartDoor.App;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();

        // === BACKEND ===
        services.AddSingleton<SmartDoorDb>(_ =>
            new SmartDoorDb("Server=(localdb)\\MSSQLLocalDB;Database=SmartDoor;Trusted_Connection=True;TrustServerCertificate=True;"));

        services.AddSingleton<AuthService>();
        services.AddSingleton<SerialService>();

        // === FRONTEND SERVICES ===
        services.AddSingleton<NavigationService>();
        services.AddSingleton<ThemeService>();

        // === VIEWMODELS ===
        services.AddTransient<SplashViewModel>();
        services.AddTransient<LoginViewModel>();
        services.AddTransient<AdminLoginViewModel>();
        services.AddTransient<UserLoginViewModel>();
        services.AddTransient<RegisterViewModel>();
        services.AddTransient<UserDashboardViewModel>();
        services.AddTransient<AdminDashboardViewModel>();
        services.AddTransient<RegisterCardViewModel>();

        // 4 ViewModel untuk menu Dashboard
        services.AddTransient<AboutViewModel>();
        services.AddTransient<MonitoringViewModel>();
        services.AddTransient<ContactViewModel>();
        services.AddTransient<CardBlockViewModel>();

        // TAMBAHAN BARU: Data Pengguna & Profil
        services.AddTransient<UserDataViewModel>();
        services.AddTransient<ProfileViewModel>();

        // === MAIN WINDOW ===
        services.AddSingleton<MainWindow>();

        Services = services.BuildServiceProvider();
        Services.GetRequiredService<MainWindow>().Show();
    }
}
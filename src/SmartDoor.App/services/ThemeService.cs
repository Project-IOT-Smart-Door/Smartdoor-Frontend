using System;
using System.Linq;
using System.Windows;

namespace SmartDoor.App.Services;

public class ThemeService
{
    public string CurrentTheme { get; private set; } = "Light";

    public event Action? ThemeChanged;

    public void ApplyLight() => ApplyTheme("Light");
    public void ApplyDark() => ApplyTheme("Dark");
    public void ApplyCustom() => ApplyTheme("Custom");

    public void ApplyTheme(string themeName)
    {
        try
        {
            // 1. Cari dictionary tema yang sedang aktif
            var oldThemeDict = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Theme.xaml"));

            // 2. Buat dictionary baru menggunakan Pack URI (Cara paling aman di WPF)
            var newThemeDict = new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/Themes/{themeName}Theme.xaml", UriKind.Absolute)
            };

            // 3. Ganti tema lama dengan tema baru tanpa menghapus style lainnya
            if (oldThemeDict != null)
            {
                int index = Application.Current.Resources.MergedDictionaries.IndexOf(oldThemeDict);
                Application.Current.Resources.MergedDictionaries[index] = newThemeDict;
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(newThemeDict);
            }

            CurrentTheme = themeName;
            ThemeChanged?.Invoke();
        }
        catch (Exception ex)
        {
            // Jika file XAML tema tidak ditemukan atau error, tampilkan pesan (bukan crash)
            MessageBox.Show($"Gagal memuat tema {themeName}.\nPastikan file {themeName}Theme.xaml ada di folder Themes.\n\nDetail: {ex.Message}",
                            "Error Tema", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
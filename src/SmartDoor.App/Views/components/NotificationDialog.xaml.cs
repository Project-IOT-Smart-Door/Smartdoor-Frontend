using System.Windows;
using System.Windows.Media;

namespace SmartDoor.App.Views.Components;

public partial class NotificationDialog : Window
{
    public enum DialogType { Success, Error, Warning, Info }

    public NotificationDialog(string title, string message, DialogType type = DialogType.Success)
    {
        InitializeComponent();

        TitleText.Text = title;
        MessageText.Text = message;

        switch (type)
        {
            case DialogType.Success:
                IconBorder.Background = new SolidColorBrush(Color.FromRgb(22, 163, 74));
                IconText.Text = "✓";
                break;
            case DialogType.Error:
                IconBorder.Background = new SolidColorBrush(Color.FromRgb(220, 38, 38));
                IconText.Text = "✕";
                break;
            case DialogType.Warning:
                IconBorder.Background = new SolidColorBrush(Color.FromRgb(245, 158, 11));
                IconText.Text = "!";
                break;
            case DialogType.Info:
                IconBorder.Background = new SolidColorBrush(Color.FromRgb(37, 99, 235));
                IconText.Text = "i";
                break;
        }
    }

    private void OkButton_Click(object sender, RoutedEventArgs e) => Close();

    // Helper statis untuk pemanggilan cepat
    public static void ShowSuccess(string title, string message)
        => new NotificationDialog(title, message, DialogType.Success).ShowDialog();

    public static void ShowError(string title, string message)
        => new NotificationDialog(title, message, DialogType.Error).ShowDialog();

    public static void ShowWarning(string title, string message)
        => new NotificationDialog(title, message, DialogType.Warning).ShowDialog();

    public static void ShowInfo(string title, string message)
        => new NotificationDialog(title, message, DialogType.Info).ShowDialog();
}
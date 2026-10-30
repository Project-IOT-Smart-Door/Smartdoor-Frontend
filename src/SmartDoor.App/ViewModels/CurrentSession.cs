namespace SmartDoor.App.ViewModels;

public static class CurrentSession
{
    public static int UserId { get; set; }
    public static string Username { get; set; } = "";
    public static string NamaLengkap { get; set; } = "";
    public static string Role { get; set; } = "";
    public static string CardUID { get; set; } = "";
}
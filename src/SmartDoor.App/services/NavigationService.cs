using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace SmartDoor.App.Services;

public partial class NavigationService : ObservableObject
{
    [ObservableProperty]
    private ObservableObject? _currentViewModel;

    public void NavigateTo<TViewModel>() where TViewModel : ObservableObject
    {
        CurrentViewModel = App.Services.GetRequiredService<TViewModel>();
    }

    public void NavigateTo(ObservableObject viewModel)
    {
        CurrentViewModel = viewModel;
    }
}
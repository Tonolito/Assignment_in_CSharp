using CommunityToolkit.Mvvm.ComponentModel;

namespace Presentation_Wpf.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject _currentViewModel = null!;
}

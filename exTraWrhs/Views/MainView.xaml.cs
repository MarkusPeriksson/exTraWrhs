using exTraWrhs.ViewModels;

namespace exTraWrhs.Views;

public partial class MainView : ContentPage
{    
    public MainView(MainViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}

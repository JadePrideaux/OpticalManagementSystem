using OpticalManagementSystemDesktop.ViewModels;
using System.Windows.Controls;

namespace OpticalManagementSystemDesktop.Views
{
    public partial class MainMenuView : UserControl
    {
        public MainMenuView(MainMenuViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}

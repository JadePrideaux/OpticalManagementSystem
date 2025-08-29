using OpticalManagementSystemDesktop.ViewModels;
using System.Windows;

namespace OpticalManagementSystemDesktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); // Root VM
        }
    }
}

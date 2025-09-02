using OpticalManagementSystemDesktop.ViewModels;
using System.Windows;

namespace OpticalManagementSystemDesktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Load the UI
            InitializeComponent();
            // Set the content to conatain data from an instance of the MainViewModel
            DataContext = new MainViewModel();
        }
    }
}

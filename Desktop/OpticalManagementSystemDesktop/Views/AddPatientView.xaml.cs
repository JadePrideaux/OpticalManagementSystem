using OpticalManagementSystemDesktop.ViewModels;
using System.Windows.Controls;

namespace OpticalManagementSystemDesktop.Views
{
    public partial class AddPatientView : UserControl
    {
        public AddPatientView(AddPatientViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}

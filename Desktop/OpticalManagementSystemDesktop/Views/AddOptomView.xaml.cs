using OpticalManagementSystemDesktop.ViewModels;
using System.Windows.Controls;

namespace OpticalManagementSystemDesktop.Views
{
    public partial class AddOptomView : UserControl
    {
        public AddOptomView(AddOptomViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}

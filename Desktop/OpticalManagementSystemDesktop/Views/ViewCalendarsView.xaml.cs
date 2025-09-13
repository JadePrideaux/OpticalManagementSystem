using OpticalManagementSystemDesktop.ViewModels;
using System.Windows.Controls;

namespace OpticalManagementSystemDesktop.Views
{
    public partial class ViewCalendarsView : UserControl
    {
        public ViewCalendarsView(CalendarsViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;

            // When the view loads, trigger appointment loading
            this.Loaded += async (s, e) =>
            {
                if (DataContext is CalendarsViewModel calendarsVm)
                {
                    // Example: hardcoded optom ID = 1 and today's date
                    await calendarsVm.LoadAppointmentsAsync(1, DateTime.Today);
                }
            };
        }
    }
}

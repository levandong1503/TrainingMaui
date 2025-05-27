using Telerik.UI.Xaml.Controls.DataVisualization.Map.BingRest;

namespace TrainingMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Features.Music.Pages.Home), typeof(Features.Music.Pages.Home));
        }
    }
}

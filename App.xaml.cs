using Anacrusa.Data;
using Anacrusa.Views;
using Anacrusa.Views.SideBar;
using Microsoft.Extensions.DependencyInjection;

namespace Anacrusa
{
    public partial class App : Application
    {
        public App(AppDatabase database)
        {
            InitializeComponent();
            _ = InitializeDatabaseAsync(database);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new SideBarPage());
        }

        private async Task InitializeDatabaseAsync(AppDatabase database)
        {
            await database.InitializeAsync();
        }
    }
}
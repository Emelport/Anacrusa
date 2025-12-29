using Anacrusa.Views;
using Anacrusa.Views.SideBar;
using Microsoft.Extensions.DependencyInjection;

namespace Anacrusa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new SideBarPage());
        }
    }
}
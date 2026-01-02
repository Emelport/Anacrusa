using Anacrusa.ViewModels;

namespace Anacrusa.Views.Library;

public partial class LibraryView : ContentView
{
	public LibraryView()
	{
		InitializeComponent();
        BindingContext = new LibraryViewModel();

    }
}
using Anacrusa.Repository;
using Anacrusa.ViewModels;

namespace Anacrusa.Views.Library;

public partial class LibraryView : ContentView
{
	readonly LibraryViewModel _vm;
	public LibraryView(LibraryViewModel vm)
	{
		InitializeComponent();
		_vm = vm;
        BindingContext = _vm;

    }

    async void OnImportClicked(object? sender, EventArgs e)
    {
        try
        {
            var results = await FilePicker.PickMultipleAsync(new PickOptions
            {
                PickerTitle = "Choose Pdfs to Import.",
                FileTypes = FilePickerFileType.Pdf
            });

            if (results != null)
                await _vm.ImportAsync(results);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }

}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Addressbook.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToUpdate()
    {
        await Shell.Current.GoToAsync("");
    }
}

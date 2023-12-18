using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Addressbook.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToAddContact()
    {
        await Shell.Current.GoToAsync("");
    }

    [RelayCommand]
    private async Task NavigateToList()
    {
        await Shell.Current.GoToAsync("");
    }

    [RelayCommand]
    private async Task NavigateToContactDetails()
    {
        await Shell.Current.GoToAsync("");
    }

    [RelayCommand]
    private async Task NavigateToUpdate()
    {
        await Shell.Current.GoToAsync("");
    }
}

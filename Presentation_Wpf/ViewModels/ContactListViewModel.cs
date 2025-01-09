using Business.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Dtos;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Presentation_Wpf.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    private readonly IContactService _contactService;
    private readonly IServiceProvider _serviceProvider;
    public ContactListViewModel(IContactService contactService, IServiceProvider serviceProvider)
    {
        _contactService = contactService;
        _serviceProvider = serviceProvider;
        // Gör om IEnumerable lista till en grafisk lista
        _contacts = new ObservableCollection<Contact>(_contactService.GetContacts());
    
    }

    // Är en lista, automatisk med flagga
    [ObservableProperty]
    private ObservableCollection<Contact> _contacts = [];



    [RelayCommand]
    private void GoToAddView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactAddViewModel>();
    }


    [RelayCommand]
    private void GoToDetailView(Contact contact)
    {

        var contactDetailsViewModel = _serviceProvider.GetRequiredService<ContactDetailsViewModel>();
        contactDetailsViewModel.Contact = contact;
        // Skickar över model vidare?

        // HÄMTA UR MainViewModel
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        // Den sida vi byter till contactDetailsViewModel;
        mainViewModel.CurrentViewModel = contactDetailsViewModel;
    }
}

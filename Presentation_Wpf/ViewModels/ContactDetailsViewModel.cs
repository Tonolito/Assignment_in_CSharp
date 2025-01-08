using Business.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Dtos;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation_Wpf.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly IContactService _contactService;
    private readonly IServiceProvider _serviceProvider;

    public ContactDetailsViewModel(IContactService contactService, IServiceProvider serviceProvider)
    {
        _contactService = contactService;
        _serviceProvider = serviceProvider;
    }

    [ObservableProperty]
    private Contact _contact = new();

    [RelayCommand]
    private void Cancel()
    {
        // HÄMTA UR MainViewModel
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        // Den sida vi byter till
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }

    [RelayCommand]
    private void GoToEditView()
    {
        var contactUpdateViewModel = _serviceProvider.GetRequiredService<ContactUpdateViewModel>();
        contactUpdateViewModel.Contact = Contact;
        // HÄMTA UR MainViewModel
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        // Den sida vi byter till
        mainViewModel.CurrentViewModel = contactUpdateViewModel;


    }
}

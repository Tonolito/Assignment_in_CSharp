using Business.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Dtos;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation_Wpf.ViewModels;

public partial class ContactAddViewModel : ObservableObject
{
    private readonly IContactService _contactService;
    private readonly IServiceProvider _serviceProvider;

    public ContactAddViewModel(IContactService contactService, IServiceProvider serviceProvider)
    {
        _contactService = contactService;
        _serviceProvider = serviceProvider;
    }

    [ObservableProperty]
    private ContactDto _contactDto = new();

    [RelayCommand]
    private void Cancel()
    {
        
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }

    [RelayCommand]
    private void Add()
    {
        var result = _contactService.AddContact(ContactDto);
        if (result)
        {
            // HÄMTA UR MainViewModel
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            // Den sida vi byter till
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
            
        }

    }
}

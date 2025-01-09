using Business.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Dtos;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation_Wpf.ViewModels;

public partial class ContactUpdateViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;

    public ContactUpdateViewModel(IContactService contactService, IServiceProvider serviceProvider)
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
    private void Edit()
    {
        var result = _contactService.UpdateContact(Contact);
        if (result)
        {
            // HÄMTA UR MainViewModel
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            // Den sida vi byter till
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
        }

    }
    [RelayCommand]
    private void Delete()
    {
        var result = _contactService.DeleteContact(Contact);
        if (result)
        {
            // HÄMTA UR MainViewModel
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            // Den sida vi byter till
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
        }

    }
}

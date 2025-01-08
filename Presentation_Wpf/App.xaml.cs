using Business.Helpers;
using Business.Interface;
using Business.Repositories;
using Business.Services;
using Data.Interfaces;
using Data.Services;
using Domain.Factories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation_Wpf.ViewModels;
using Presentation_Wpf.Views;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;

namespace Presentation_Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IContactService, ContactService>();
                    services.AddTransient<IContactFactory, ContactFactory>();
                    services.AddTransient<IContactRepository, ContactRepository>();
                    services.AddTransient<IFileService, FileService>();
                    services.AddTransient<IIdGenerator, IdGenerator>();

                    services.AddTransient<ContactAddViewModel>();
                    services.AddTransient<ContactListViewModel>();
                    services.AddTransient<ContactUpdateViewModel>();
                    services.AddTransient<ContactDetailsViewModel>();

                    services.AddTransient<ContactAddView>();
                    services.AddTransient<ContactListView>();
                    services.AddTransient<ContactUpdateView>();
                    services.AddTransient<ContactDetailsView>();


                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainViewModel = _host.Services.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _host.Services.GetRequiredService<ContactListViewModel>();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}

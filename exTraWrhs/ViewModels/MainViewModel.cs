using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using exTraWrhs.Models;
using exTraWrhs.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exTraWrhs.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public ObservableCollection<MainMenuModel> MenuItems { get; set; } = new();
        private INavigationService _navigationService;

        [ObservableProperty]
        public MainMenuModel selectedItem;

        [RelayCommand]
        private async Task ItemSelected(MainMenuModel selectedItem)
        {
           await _navigationService.NavigateToAsync($"{selectedItem.Naziv}");
        }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuItems.Add(new MainMenuModel()
            {
                Naziv = "Prikupljanje",
                Logo = "prikupljanje.svg"                
            });

            MenuItems.Add(new MainMenuModel()
            {
                Naziv = "Pakiranje",
                Logo = "pakiranje.svg"
            });

            MenuItems.Add(new MainMenuModel()
            {
                Naziv = "Inventura",
                Logo = "inventura.svg"
            });

            MenuItems.Add(new MainMenuModel()
            {
                Naziv = "Zapisnik",
                Logo = "zapisnik.svg"
            });

            MenuItems.Add(new MainMenuModel()
            { 
                Naziv = "Osnovna sredstva",
                Logo = "osredstva.svg"
            });

            MenuItems.Add(new MainMenuModel()
            {
                Naziv = "Stanje", 
                Logo = "stanje.svg"
            });

            MenuItems.Add(new MainMenuModel()
            {
                Naziv = "EMVS",
                Logo = "emvs.svg"
            });

            MenuItems.Add(new MainMenuModel()
            {
                Naziv = "Administracija sustava",
                Logo = "administracija.svg"
            });
        }
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel;
using RealPromo.Mobile.Models;
using RealPromo.Mobile.Services;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealPromo.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Promocao> lista = new ObservableCollection<Promocao>();
        public MainPage()
        {
            InitializeComponent();

            new SignalService(lista);

            ListViewPromocao.ItemsSource = lista;
        }
    }
}
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using RealPromo.Mobile.Models;

namespace RealPromo.Mobile.Services
{
    public class SignalService
    {
        public SignalService(ObservableCollection<Promocao> lista)
        {
            Task.Run(async()=> { await Configure(lista); });
        }

        private async Task Configure(ObservableCollection<Promocao> lista)
        {
            var connection = new HubConnectionBuilder().WithUrl("https://localhost:5011/PromoHub").Build();

            connection.On<Promocao>("ReceberPromocao", (promocao) => {
                Xamarin.Forms.Device.InvokeOnMainThreadAsync(() => {
                    lista.Add(promocao);
                });
            });

            connection.Closed += async (error) => {
                await Task.Delay(5000);
                await connection.StartAsync();
            };

            await connection.StartAsync();
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RealPromo.Application.Models;

namespace RealPromo.Application.Hubs
{
    public class PromoHub : Hub
    {
        public async Task CadastrarPromocao(Promocao promo)
        {
            await Clients.Caller.SendAsync("CadastradoSucesso");
            await Clients.Others.SendAsync("ReceberPromocao", promo);
        }
    }
}

using NatilleraEventos.Models;

namespace NatilleraEventos.Services
{
    public interface IAuthService
    {
        string Authenticate(Admin login);
    }
}

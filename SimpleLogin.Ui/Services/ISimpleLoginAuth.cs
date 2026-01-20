using System.Threading.Tasks;

namespace SimpleLogin.Ui.Services
{
    public interface ISimpleLoginAuth
    {
        Task<bool> ValidateUserAsync(string username, string password);
    }
}

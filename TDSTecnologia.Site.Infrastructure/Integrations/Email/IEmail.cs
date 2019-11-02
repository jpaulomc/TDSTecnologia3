using System.Threading.Tasks;

namespace TDSTecnologia.Site.Infrastructure.Integrations.Email
{
    public interface IEmail
    {
        Task EnviarEmail(string email, string assunto, string mensagem);
    }
}

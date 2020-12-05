using System;
using System.Threading.Tasks;

namespace GestionStageEquipe7.Services.Courriels
{
    public interface IEmailService
    {
        Task<Exception> Send(EmailMessage emailMessage);
    }


}
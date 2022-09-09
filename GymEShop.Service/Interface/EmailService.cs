using GymEShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymEShop.Service.Interface
{
    public interface EmailService
    {
        Task SendEmailAsync(List<EmailMessage> mail);
    }
}

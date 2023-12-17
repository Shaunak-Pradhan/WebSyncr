using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevPortal.Services.Interface
{
    public interface IFeaturesService
    {
        void URLRewrite(string URL, string NewURL);
        string PostPaymentInfo(Guid OrderReference, string RequestID, string Email);
        string GetPaymentStatus(string Orderid, string refno);
        string GenerateAccessToken();
        Task<string> SendEmailAsync(string recipientEmail, string subject, string body);
        Task SendEmailAsync(string subject, string body, List<string> recipientEmails, List<string> ccEmails, List<string> bccEmails);
    }
}

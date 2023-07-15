namespace EduApp.Areas.EduAdmin.Data.Service;

public interface IEmailService
{
    void Send(string to, string subject, string html, string from = null);
}

namespace notification_service.Services;

public interface IEmailService
{
    void SendStandardEmail(EmailDto request);
}
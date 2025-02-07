namespace CleanArchitecture.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync( Domain.Entities.Users.Emails recipient, string subject, string body );
}

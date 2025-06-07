namespace CleanArchitecture.Infrastructure.Email;

using CleanArchitecture.Application.Abstractions.Email;
using CleanArchitecture.Domain.Entities.Users;
using System.Threading.Tasks;

public sealed class EmailService : IEmailService
{
    public Task SendAsync( Emails recipient, string subject, string body )
    {
        return Task.CompletedTask;
    }
}

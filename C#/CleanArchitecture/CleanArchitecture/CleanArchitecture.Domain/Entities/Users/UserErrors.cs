using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Entities.Users;

public static class UserErrors
{
    public static Error NotFound = new("User.NotFound", "The user does not exist.");

    public static Error InvalidCredentials = new("User.InavalidCredentials", "The credentials does not are valid.");
}

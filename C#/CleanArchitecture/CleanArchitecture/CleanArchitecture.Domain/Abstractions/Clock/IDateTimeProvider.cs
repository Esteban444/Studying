namespace CleanArchitecture.Domain.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime CurrenTime { get; }
}

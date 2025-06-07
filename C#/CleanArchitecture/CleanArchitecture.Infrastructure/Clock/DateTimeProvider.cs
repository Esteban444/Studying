namespace CleanArchitecture.Infrastructure.Clock;

using CleanArchitecture.Application.Abstractions.Clock;
using System;

public sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrenTime => DateTime.UtcNow;
}

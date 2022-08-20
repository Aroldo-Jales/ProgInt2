using ProgInt2.Application.Common.Interfaces.Services;

namespace ProgInt2.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.Now;
    }
}
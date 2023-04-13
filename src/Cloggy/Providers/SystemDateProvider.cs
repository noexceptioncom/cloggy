namespace Cloggy.Providers;

public class SystemDateProvider : IDateTimeProvider
{
    public DateTime Now()
    {
        return DateTime.Now;
    }
}
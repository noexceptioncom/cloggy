namespace Cloggy.Formatters;

public interface IFormatStrategy
{
    public string FormatMessage(Message message);
}
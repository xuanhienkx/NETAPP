using DSoft.Common.Shared.Interfaces;
using Newtonsoft.Json;

namespace DSoft.Common.Exceptions;

public abstract class DSoftException : Exception
{
    protected DSoftException() { }
    protected DSoftException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected abstract string Detail();

    public override string Message => $"{base.Message}. Detail: {Detail()}";
}
public class NotAuthenticationException : DSoftException
{
    private readonly string data;

    public NotAuthenticationException(string message, Exception innerException, string data)
        : base(message, innerException)
    {
        this.data = data;
    }

    protected override string Detail()
    {
        return $"Error : {data}";
    }
}

public class ParseFailureException : DSoftException
{
    private readonly string data;
    private readonly CSValueType type;
    private readonly string format;

    public ParseFailureException(string message, Exception innerException, string data, CSValueType type, string format)
        : base(message, innerException)
    {
        this.data = data;
        this.type = type;
        this.format = format;
    }

    protected override string Detail()
    {
        return $"Value type: {type} - Format: {format}.  Data: {data}";
    }
}
public class BuildFailureException : DSoftException
{
    private readonly object data;
    private readonly CSValueType type;
    private readonly string format;

    public BuildFailureException(string message, Exception innerException, object data, CSValueType type, string format)
        : base(message, innerException)
    {
        this.data = data;
        this.type = type;
        this.format = format;
    }

    protected override string Detail()
    {
        return $"Value type: {type} - Format: {format}.  Data: {JsonConvert.SerializeObject(data)}";
    }
}

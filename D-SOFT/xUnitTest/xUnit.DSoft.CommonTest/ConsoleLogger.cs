using Xunit.Abstractions;

namespace xUnit.DSoft.CommonTest;

public class ConsoleLogger
{
    private readonly ITestOutputHelper output;

    public ConsoleLogger(ITestOutputHelper output)
    {
        this.output = output ?? throw new ArgumentNullException(nameof(output));
    }

    public void LogInfo(string format)
    {
        output.WriteLine(format);
    }

    public void LogInfo(string format, params object[] args)
    {
        output.WriteLine(format, args);
    }

    public void LogDebug(string format)
    {
        output.WriteLine(format);
    }

    public void LogDebug(string format, params object[] args)
    {
        output.WriteLine(format, args);
    }

    public void LogError(string format)
    {
        output.WriteLine(format);
    }

    public void LogError(string format, params object[] args)
    {
        output.WriteLine(format, args);
    }

    public void LogError(Exception exception)
    {
        output.WriteLine("ErrorMessage: {0}. Stacktrace:{1}", exception.Message, exception.StackTrace);
    }

    public void LogError(Exception exception, string format, params object[] args)
    {
        output.WriteLine(format, args);
    }
}

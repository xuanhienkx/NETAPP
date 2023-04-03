using DSoft.Common.Exceptions;

namespace DSoft.Common.Extensions;

public static class SecureExecutionExtensions
{
    public static void TryOrThrows(this Action action, Func<string, Exception, DSoftException> throwwedException)
    {
        try
        {
            action.Invoke();
        }
        catch (Exception e)
        {
            throw throwwedException(e.Message, e) ?? e;
        }
    }

    public static T TryOrThrows<T>(this Func<T> action, Func<string, Exception, DSoftException> throwwedException)
    {
        try
        {
            return action.Invoke();
        }
        catch (Exception e)
        {
            throw throwwedException(e.Message, e) ?? e;
        }
    }

    public static async Task<T> TryOrThrowsAsync<T>(this Func<Task<T>> action, Func<string, Exception, DSoftException> throwwedException)
    {
        try
        {
            return await action.Invoke();
        }
        catch (Exception e)
        {
            throw throwwedException(e.Message, e) ?? e;
        }
    }

    public static void Try<T>(this Action action, Action<T> expectedException, bool throwsException = false) where T : Exception
    {
        try
        {
            action();
        }
        catch (T exception)
        {
            expectedException?.Invoke(exception);
            if (throwsException)
                throw;
        }
    }

    public static async Task<bool> TryAsync<T>(this Func<Task> action, Action<T> expectedException, bool throwsException = false) where T : Exception
    {
        try
        {
            await action();
            return true;
        }
        catch (T exception)
        {
            expectedException?.Invoke(exception);
            if (throwsException)
                throw;

            return false;
        }
    }
}


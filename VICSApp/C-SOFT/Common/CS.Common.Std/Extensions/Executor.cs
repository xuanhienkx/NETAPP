using System;
using System.Threading.Tasks;

namespace CS.Common.Std.Extensions
{
    public static class Executor
    {
        public static void Try(Action action, Action<Exception> expectedException, bool throwsException = false)
        {
            action.Try(expectedException, throwsException);
        }

        public static async Task<bool> TryAsync(Func<Task> action, Action<Exception> expectedException, bool throwsException = false)
        {
            try
            {
                await action.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                expectedException?.Invoke(ex);

                if (throwsException)
                    throw;

                return false;
            }
        }
        
        public static async Task<T> TryAsync<T>(Func<Task<T>> action, Action<Exception> expectedException, bool throwsException = false)
        {
            try
            {
                return await action.Invoke();
            }
            catch (Exception ex)
            {
                expectedException?.Invoke(ex);

                if (throwsException)
                    throw;

                return default(T);
            }
        }

        public static bool Try<T>(Func<T> method, out T @return, Action<Exception> onException = null)
        {
            try
            {
                @return = method.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                onException?.Invoke(ex);

                @return = default(T);
                return false;
            }
        }

        public static T TryOrThrows<T>(Func<T> action, Func<string, Exception, CsException> throwwedException)
        {
            return action.TryOrThrows(throwwedException);
        }

        public static Task<T> TryOrThrowsAsync<T>(Func<Task<T>> action, Func<string, Exception, CsException> throwwedException)
        {
            return action.TryOrThrows(throwwedException);
        }
    }
}
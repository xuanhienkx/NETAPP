using CircuitBreaker.Net.Exceptions;
using System;
using System.Threading.Tasks;

namespace CS.Common.Extensions
{
    public class CircuitBreakerOptions
    {
        public CircuitBreakerOptions()
        {
            MaxAttemptFailure = 3;
            ExecuteTimeOut = TimeSpan.FromMilliseconds(5000);
            ResetTimeOut = TimeSpan.FromMilliseconds(10000);
        }
        public Action<CircuitBreakerOpenException> BreakerOpened { get; set; }
        public Action<CircuitBreakerTimeoutException> BreakerTimeout { get; set; }
        public Action<Exception> UnkownException { get; set; }
        public int Attempt { get; set; }
        public int MaxAttemptFailure { get; set; }
        public TimeSpan ExecuteTimeOut { get; set; }
        public TimeSpan ResetTimeOut { get; set; }
    }

    public static class CircuitBreakerExtensions
    {
        public static void CircuitBreakerExecute(this Action externalService, Action<CircuitBreakerOptions> handlerOptions = null)
        {
            // setup options
            var options = new CircuitBreakerOptions();
            handlerOptions?.Invoke(options);

            // Initialize the circuit breaker
            var circuitBreaker = new CircuitBreaker.Net.CircuitBreaker(
                TaskScheduler.Current,
                options.MaxAttemptFailure,
                options.ExecuteTimeOut,
                options.ResetTimeOut);

            while (true)
            {
                try
                {
                    // perform a potentially fragile call through the circuit breaker
                    circuitBreaker.Execute(externalService.Invoke);
                }
                catch (CircuitBreakerOpenException open)
                {
                    options.Attempt++;
                    options.BreakerOpened?.Invoke(open);
                    break;
                }
                catch (CircuitBreakerTimeoutException timeoutEx)
                {
                    options.Attempt++;
                    options.BreakerTimeout?.Invoke(timeoutEx);
                }
                catch (Exception e)
                {
                    options.Attempt++;
                    options.UnkownException?.Invoke(e);
                }
            }
        }

        public static async Task CircuitBreakerExecuteAsync(this Func<Task> externalService, Action<CircuitBreakerOptions> handlerOptions = null)
        {
            // setup options
            var options = new CircuitBreakerOptions();
            handlerOptions?.Invoke(options);

            // Initialize the circuit breaker
            var circuitBreaker = new CircuitBreaker.Net.CircuitBreaker(
                TaskScheduler.Current,
                options.MaxAttemptFailure,
                options.ExecuteTimeOut,
                options.ResetTimeOut);

            while (true)
            {
                try
                {
                    // perform a potentially fragile call through the circuit breaker
                    await circuitBreaker.ExecuteAsync(externalService);
                }
                catch (CircuitBreakerOpenException open)
                {
                    options.BreakerOpened?.Invoke(open);
                    break;
                }
                catch (CircuitBreakerTimeoutException timeoutEx)
                {
                    options.Attempt++;
                    options.BreakerTimeout?.Invoke(timeoutEx);
                }
                catch (Exception e)
                {
                    options.Attempt++;
                    options.UnkownException?.Invoke(e);
                }
            }
        }

        public static T CircuitBreakerExecute<T>(this Func<T> externalService, Action<CircuitBreakerOptions> handlerOptions = null)
        {
            // setup options
            var options = new CircuitBreakerOptions();
            handlerOptions?.Invoke(options);

            // Initialize the circuit breaker
            var circuitBreaker = new CircuitBreaker.Net.CircuitBreaker(
                TaskScheduler.Current,
                options.MaxAttemptFailure,
                options.ExecuteTimeOut,
                options.ResetTimeOut);

            while (true)
            {
                try
                {
                    return circuitBreaker.Execute(externalService);
                }
                catch (CircuitBreakerOpenException open)
                {
                    options.BreakerOpened?.Invoke(open);
                    return default(T);
                }
                catch (CircuitBreakerTimeoutException timeoutEx)
                {
                    options.Attempt++;
                    options.BreakerTimeout?.Invoke(timeoutEx);
                }
                catch (Exception e)
                {
                    options.Attempt++;
                    options.UnkownException?.Invoke(e);
                }
            }
        }

        public static async Task<T> CircuitBreakerExecuteAsync<T>(this Func<Task<T>> externalService, Action<CircuitBreakerOptions> handlerOptions = null)
        {
            // setup options
            var options = new CircuitBreakerOptions();
            handlerOptions?.Invoke(options);

            // Initialize the circuit breaker
            var circuitBreaker = new CircuitBreaker.Net.CircuitBreaker(
                TaskScheduler.Current,
                options.MaxAttemptFailure,
                options.ExecuteTimeOut,
                options.ResetTimeOut);

            while (true)
            {
                try
                {
                    return await circuitBreaker.ExecuteAsync(externalService);
                }
                catch (CircuitBreakerOpenException open)
                {
                    options.BreakerOpened?.Invoke(open);
                    return default(T);
                }
                catch (CircuitBreakerTimeoutException timeoutEx)
                {
                    options.Attempt++;
                    options.BreakerTimeout?.Invoke(timeoutEx);
                    return default(T);
                }
                catch (Exception e)
                {
                    options.Attempt++;
                    options.UnkownException?.Invoke(e);
                    return default(T);
                }
            }
        }
    }
}
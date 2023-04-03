namespace DSoft.Common.Shared;

public class Result<T>
{
    public Result()
    {
        Errors = new List<string>();
    }

    public Result(T value) : this()
    {
        Value = value;
    }

    public Result(params string[] errors) : this()
    {
        Errors = errors;
    }

    public Result(IList<string> errors) : this()
    {
        Errors = errors;
    }

    public bool Succeeded => Errors.Count == 0;
    public T Value { get; }
    public IList<string> Errors { get; set; }
}

public static class Result
{
    public static Result<T> Value<T>(T value)
    {
        return new Result<T>(value);
    }

    public static Result<T> Error<T>(params string[] errors)
    {
        return new Result<T>(new List<string>(errors));
    }

    public static Result<string> Error(params string[] errors)
    {
        return new Result<string>(new List<string>(errors));
    }

    public static Result<string> Error(IList<string> errors)
    {
        return new Result<string>(errors);
    }
}

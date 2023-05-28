using LifeStat.Domain.Shared.Errors;
using System.Diagnostics;

namespace LifeStat.Domain.Shared;
public class Result
{
    protected Result(Error[] errors)
    {
        Errors = errors;
    }

    protected Result()
    {
        Errors = Array.Empty<Error>();
    }

    public static Result FromErrors(IEnumerable<Error> errors)
    {
        return new Result(errors.ToArray());
    }

    public static Result FromError(Error error)
    {
        return new Result(new Error[] { error });
    }

    public static Result Good()
    {
        return new Result();
    }

    public Result MergeFrom(Result result)
    {
        var mergedErrors = Errors.Concat(result.Errors).ToArray();
        return new Result(mergedErrors);
    }

    public Error[] Errors { get; init; }

    public bool IsSucceeded { get => Errors.Any(); }
}


public class Result<T> : Result where T : new()
{
    private Result(T value)
    {
        Value = value;
    }

    private Result(T value, Error[] errors) : base(errors)
    {
        Value = value;
    }

    public new static Result<T> FromErrors(IEnumerable<Error> errors)
    {
        return new Result<T>(new T(), errors.ToArray());
    }

    public static Result<T> FromErrors(T? value, IEnumerable<Error> errors)
    {
        return new Result<T>(value ?? new T(), errors.ToArray());
    }

    public new static Result<T> FromError(Error error)
    {
        return new Result<T>(new T(), new Error[] { error });
    }

    public static Result<T> FromError(T? value, Error error)
    {
        return new Result<T>(value ?? new T(), new Error[] { error });
    }

    public static Result<T> Good(T value)
    {
        return new Result<T>(value);
    }

    public T Value { get; init; }

}
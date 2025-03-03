using FluentResults;

namespace ProSpaceTestTask;

public static class Extensions
{
    //пристройка (расширение) к классу Result, чтобы не лезть в нугет, а написать метод снаружи
    public static string StringifyErrors<T>(this Result<T> result)
    {
        return string.Join(";", result.Errors.Select(x => x.Message));
    }
    public static string StringifyErrors(this Result result)
    {
        return string.Join(";", result.Errors.Select(x => x.Message));
    }
}
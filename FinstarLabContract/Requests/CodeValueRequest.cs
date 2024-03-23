namespace FinstarLab.Contract.Requests;

public class CodeValueRequest : IComparable<CodeValueRequest>
{
    public int Code { get; init; }
    public string Value { get; init; } = null!;

    public int CompareTo(CodeValueRequest? other)
    {
        return other != null ? Code.CompareTo(other.Code) : 1;
    }
}
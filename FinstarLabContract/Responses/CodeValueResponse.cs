namespace FinstarLab.Contract.Responses;

public class CodeValueResponse
{
    public int Id { get; init; }
    public int Code { get; init; }
    public string Value { get; init; } = null!;
}
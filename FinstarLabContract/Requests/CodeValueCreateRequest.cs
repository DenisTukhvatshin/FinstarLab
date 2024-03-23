namespace FinstarLab.Contract.Requests;

public class CodeValueCreateRequest : List<CodeValueRequest>
{
    public void SortByKey()
    {
        Sort((x, y) => x.Code.CompareTo(y.Code));
    }
}
using FinstarLab.Contract.Requests;
using FinstarLab.Contract.Responses;

namespace FinstarLab.Contract.Interfaces.Queries;

public interface ICodeValueQuery
{
    Task<CodeValuesResponse> GetAsync(CodeValueGetRequest codeValueGetRequest, CancellationToken cancellationToken = default);
}

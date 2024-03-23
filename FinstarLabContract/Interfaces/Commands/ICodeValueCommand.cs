using FinstarLab.Contract.Requests;

namespace FinstarLab.Contract.Interfaces.Commands;

public interface ICodeValueCommand
{
    Task Create(CodeValueCreateRequest codeValueRequest, CancellationToken cancellationToken = default);
}
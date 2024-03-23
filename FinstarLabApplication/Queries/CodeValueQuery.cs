using FinstarLab.Contract.Interfaces.Queries;
using FinstarLab.Contract.Requests;
using FinstarLab.Contract.Responses;
using FinStarLab.Db;
using Microsoft.EntityFrameworkCore;

namespace FinstarLab.Application.Queries;

public class CodeValueQuery : ICodeValueQuery
{
    private readonly FinstarLabContext _finstarLabContext;

    public CodeValueQuery(FinstarLabContext finstarLabContext)
    {
        _finstarLabContext = finstarLabContext;
    }
    public async Task<CodeValuesResponse> GetAsync(CodeValueGetRequest codeValueGetRequest, CancellationToken cancellationToken = default)
    {
        var codeValuesResponse = new CodeValuesResponse();

        // Получаем данные по фильтрам
        var dataFromDb = await _finstarLabContext.CodeValues.Where(a =>
           (codeValueGetRequest.Id == null || codeValueGetRequest.Id == a.Id) &&
           (codeValueGetRequest.Code == null || codeValueGetRequest.Code == a.Code) &&
           (codeValueGetRequest.Value == null || codeValueGetRequest.Value == a.Value)
        ).ToListAsync(cancellationToken: cancellationToken);

        // Собираем ответ
        codeValuesResponse.AddRange(
            dataFromDb.Select(data =>
                new CodeValueResponse() { Id = data.Id, Code = data.Code, Value = data.Value }
            )
        );

        // Возвращаем ответ
        return codeValuesResponse;
    }
}

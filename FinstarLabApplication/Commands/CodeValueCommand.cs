using FinstarLab.Contract.Interfaces.Commands;
using FinstarLab.Contract.Requests;
using FinstarLab.Db.Entities;
using FinStarLab.Db;

namespace FinstarLab.Application.Commands;

public class CodeValueCommand : ICodeValueCommand
{
    private readonly FinstarLabContext _finstarLabContext;

    public CodeValueCommand(FinstarLabContext finstarLabContext)
    {
        _finstarLabContext = finstarLabContext;
        _finstarLabContext.Database.EnsureCreated();
    }

    public async Task Create(CodeValueCreateRequest codeValueRequest, CancellationToken cancellationToken = default)
    {
        // Отсортировать данные
        codeValueRequest.SortByKey();

        // Удалить все данные из таблицы (можно воспользоваться запросом truncate with restart identity)
        _finstarLabContext.CodeValues.RemoveRange(_finstarLabContext.CodeValues.ToList());

        // Добавить в БД данные из запроса
        foreach (var codeValue in codeValueRequest)
        {
            await _finstarLabContext.AddAsync(new CodeValue()
            {
                Code = codeValue.Code,
                Value = codeValue.Value
            }, cancellationToken);
        }

        // Сохранение изменений
        await _finstarLabContext.SaveChangesAsync(cancellationToken);

    }
}
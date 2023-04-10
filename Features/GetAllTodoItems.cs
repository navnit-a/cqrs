using MediatR;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class GetAllTodoItems : IRequest<List<TodoItem>>
{
}

public class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItems, List<TodoItem>>
{
    private const string FilePath = "todoItems.json";

    public async Task<List<TodoItem>> Handle(GetAllTodoItems request, CancellationToken cancellationToken)
    {
        return await ReadTodoItemsFromFileAsync();
    }

    private async Task<List<TodoItem>> ReadTodoItemsFromFileAsync()
    {
        if (!File.Exists(FilePath))
        {
            return new List<TodoItem>();
        }

        var jsonString = await File.ReadAllTextAsync(FilePath);
        return JsonSerializer.Deserialize<List<TodoItem>>(jsonString);
    }
}

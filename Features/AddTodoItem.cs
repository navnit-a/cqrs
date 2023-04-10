using MediatR;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class AddTodoItem : IRequest<bool>
{
    public TodoItem TodoItem { get; set; }
}

public class AddTodoItemHandler : IRequestHandler<AddTodoItem, bool>
{
    private const string FilePath = "todoItems.json";

    public async Task<bool> Handle(AddTodoItem request, CancellationToken cancellationToken)
    {
        var todoItems = await ReadTodoItemsFromFileAsync();

        todoItems.Add(request.TodoItem);

        await WriteTodoItemsToFileAsync(todoItems);

        return true;
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

    private async Task WriteTodoItemsToFileAsync(List<TodoItem> todoItems)
    {
        var jsonString = JsonSerializer.Serialize(todoItems);
        await File.WriteAllTextAsync(FilePath, jsonString);
    }
}

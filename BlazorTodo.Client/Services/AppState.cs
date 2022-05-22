using BlazorTodo.Client.Models;
using Serilog;

namespace BlazorTodo.Client.Services;

public class AppState
{
    private readonly StorageService _storageService;
    private readonly List<TodoItem> _todoList = new();

    public event Action OnChange = delegate { };

    public AppState(StorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task<IEnumerable<TodoItem>> GetTodos()
    {
        if (_todoList.Count > 0)
            return _todoList;

        var storageData = await _storageService.GetItemAsync<List<TodoItem>>(StorageKeys.TodoList);
        if (storageData?.Count > 0)
            _todoList.AddRange(storageData);

        return _todoList;
    }

    public async Task AddTodo(TodoItem todo)
    {
        Log.Information("Adding Todo {@todo}", todo);

        _todoList.Add(todo);
        await NotifyStateChanged();
    }

    public async Task RemoveAllTodos()
    {
        Log.Information("Clearing todos");
        _todoList.Clear();
        await NotifyStateChanged();
    }

    public async Task DeleteTodo(TodoItem todo)
    {
        Log.Information("Removing Todo {@todo}", todo);
        _todoList.Remove(todo);
        await NotifyStateChanged();
    }

    public async Task Sync()
    {
        Log.Information("Syncing state");
        await NotifyStateChanged();
    }

    private async Task NotifyStateChanged()
    {
        await _storageService.SetItemAsync(StorageKeys.TodoList, _todoList);
        OnChange?.Invoke();
    }
}

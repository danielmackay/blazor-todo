using BlazorTodo.Client.Models;

namespace BlazorTodo.Client.Services;

public class TodoListState
{
    private readonly StorageService _storage;

    public TodoListState(StorageService sessionStorage)
    {
        this._storage = sessionStorage;
    }

    public async Task<List<TodoItem>?> Get()
    {
        return await _storage.GetItemAsync<List<TodoItem>>(StorageKeys.TodoList);
    }

    public async Task Set(List<TodoItem> todoItems)
    {
        await _storage.SetItemAsync(StorageKeys.TodoList, todoItems);
    }
}

using BlazorTodo.Client.Models;

namespace BlazorTodo.Client.Services;

public class TodoListState
{
    private readonly StorageService storage;

    private const string storageKey = "BlazorTodo.Client.TodoList";

    public TodoListState(StorageService sessionStorage)
    {
        this.storage = sessionStorage;
    }

    public async Task<List<TodoItem>?> Get()
    {
        return await storage.GetItemAsync<List<TodoItem>>(storageKey);
    }

    public async Task Set(List<TodoItem> todoItems)
    {
        await storage.SetItemAsync(storageKey, todoItems);
    }
}

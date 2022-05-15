namespace BlazorTodo.Client.Models;

public class Todo
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Text { get; set; } = string.Empty;
}

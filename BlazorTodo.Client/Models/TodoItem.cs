﻿namespace BlazorTodo.Client.Models;

public class TodoItem
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = string.Empty;

    public bool IsComplete { get; set; } = false;
}

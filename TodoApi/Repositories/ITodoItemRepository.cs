using System;
using TodoApi.Models;
using TodoApi.Models.Domain;
using TodoApi.Models.DTO;

namespace TodoApi.Repositories
{
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetTodoItems();

        Task<TodoItem?> GetTodoItem(Guid Id);

        Task<TodoItem> CreateTodoItem(TodoItem todoItem);

        Task<TodoItem?> UpdateTodoItem(Guid Id, TodoItem todoItem);

        Task<TodoItem?> DeleteTodoItem(Guid Id);

    }
}


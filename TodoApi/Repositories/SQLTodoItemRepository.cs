using System;
using TodoApi.Models.Domain;
using TodoApi.Data;
using TodoApi.Models;
using TodoApi.Models.DTO;

using Microsoft.EntityFrameworkCore;

namespace TodoApi.Repositories
{
    public class SQLTodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _context;

        public SQLTodoItemRepository(TodoContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<TodoItem>> GetTodoItems()
        {
            //return await _context.TodoItems.Select((TodoItem x) => ItemToDTO(x)).ToListAsync();

            return await _context.TodoItems.ToListAsync();


        }

        public async Task<TodoItem?> GetTodoItem(Guid Id)
        {
            return await _context.TodoItems.FindAsync(Id);

        }



        public async Task<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            await _context.TodoItems.AddAsync(todoItem);

            await _context.SaveChangesAsync();
            return todoItem;

        }

        public async Task<TodoItem?> UpdateTodoItem(Guid Id, UpdateTodoItemDTO todoItem)
        {
            var exixtingTodoItem = await _context.TodoItems.FindAsync(Id);

            if (exixtingTodoItem == null)
            {
                return null;
            }

            exixtingTodoItem.Name = todoItem.Name;
            exixtingTodoItem.IsComplete = todoItem.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(Id))
            {

                return null;
            }

            return exixtingTodoItem;
        }

        public async Task<TodoItem?> DeleteTodoItem(Guid Id)
        {
            var ItemToDelete = await _context.TodoItems.FindAsync(Id);

            if (ItemToDelete == null)
            {
                return null;
            }

            _context.TodoItems.Remove(ItemToDelete);
            await _context.SaveChangesAsync();

            return ItemToDelete;
        }


        private bool TodoItemExists(Guid id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }

}


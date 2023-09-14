using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models.Domain;
using TodoApi.Models.DTO;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemsController(TodoContext context, ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            // Get data from database = Domain models
            var todoItems = await _todoItemRepository.GetTodoItems();
            if (todoItems == null)
            {
                return NotFound();
            }

            var todoItemsDTO = new List<TodoItemDTO>();
            foreach (var todoItem in todoItems)
            {
                todoItemsDTO.Add(ItemToDTO(todoItem));
            }
            // var todoItemsToDTO = todoItems.Select((TodoItem x) => ItemToDTO(x));


            // return DTO's to client   
            return Ok(todoItemsDTO);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(Guid id)
        {

            var todoItem = await _todoItemRepository.GetTodoItem(id);
            Console.WriteLine(todoItem);
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(ItemToDTO(todoItem));
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> PutTodoItem(Guid id, UpdateTodoItemDTO todoDTO)
        {

            var UpdatedtodoItem = await _todoItemRepository.UpdateTodoItem(id, todoDTO);

            if (UpdatedtodoItem == null) return NotFound();
            return Ok(ItemToDTO(UpdatedtodoItem));
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem(AddTodoItemDTO todoDTO)
        {
            var todoItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                IsComplete = todoDTO.IsComplete,
                Name = todoDTO.Name,
                Secret = todoDTO.Secret
            };

            var createdTodoItem = await _todoItemRepository.CreateTodoItem(todoItem);

            return CreatedAtAction(
                nameof(GetTodoItem),
                new
                {
                    id = createdTodoItem.Id,

                },
               createdTodoItem);

        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {

            var deletedItem = await _todoItemRepository.DeleteTodoItem(id);
            if (deletedItem == null)
            {
                return null;
            }
            return Ok(ItemToDTO(deletedItem));
        }


        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
            new TodoItemDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete,

            };
    }
}

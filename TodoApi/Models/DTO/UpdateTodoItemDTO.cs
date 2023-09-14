using System;
namespace TodoApi.Models.DTO
{
    public class UpdateTodoItemDTO
    {
        public string Name { get; set; } = null!;
        public bool IsComplete { get; set; }
    }
}


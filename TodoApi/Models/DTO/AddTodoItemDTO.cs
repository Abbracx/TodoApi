using System;
namespace TodoApi.Models.DTO
{
    public class AddTodoItemDTO
    {

        public string Name { get; set; } = null!;
        public bool IsComplete { get; set; }
        public string? Secret { get; set; }
    }
}


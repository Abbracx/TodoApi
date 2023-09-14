using System;
namespace TodoApi.Models.Domain
{
    public class PriorityItem
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;
    }
}


using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models.Domain;

public class TodoItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }

    public Guid PriorityId { get; set; }

    // Navigation fields
    public PriorityItem priority { get; set; }
}

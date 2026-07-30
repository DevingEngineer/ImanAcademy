namespace ImanAcademy.Models;

public class SubModule
{
    public Guid Id { get; set; }

    public Guid ModuleId { get; set; }
    public Module Module { get; set; } = null!;

    // ----- Metadata (flattened) -----
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int Order { get; set; }
    public int? EstimatedDurationMinutes { get; set; }

    // ----- Relationships -----
    public ICollection<Step> Steps { get; set; } = new List<Step>();
}

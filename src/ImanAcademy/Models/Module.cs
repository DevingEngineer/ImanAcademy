namespace ImanAcademy.Models;

public class Module
{
    public Guid Id { get; set; }

    public Guid CourseId { get; set; }
    public Course Course { get; set; } = null!;

    // ----- Metadata (flattened) -----
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int Order { get; set; }
    public int? EstimatedDurationMinutes { get; set; }
    public ContentStatus Status { get; set; }

    // ----- Relationships -----
    public ICollection<SubModule> SubModules { get; set; } = new List<SubModule>();
}

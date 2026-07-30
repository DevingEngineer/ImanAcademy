namespace ImanAcademy.Models;

public class Course
{
    public Guid Id { get; set; }

    // ----- Metadata (flattened onto the entity — see notes) -----
    public string Title { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public List<string> Tags { get; set; } = new();   // primitive collection -> JSON column
    public CourseLevel Level { get; set; }
    public string Language { get; set; } = null!;
    public decimal Price { get; set; }
    public string Currency { get; set; } = null!;      // e.g. "USD"
    public ContentStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // ----- Relationships -----
    public ICollection<Module> Modules { get; set; } = new List<Module>();
    public ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
}

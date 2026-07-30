namespace ImanAcademy.Models;

public class Instructor
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }

    public ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
}

/// <summary>
/// Join entity for the Course &lt;-&gt; Instructor many-to-many relationship.
/// Replaces the TS "instructorIds: EntityId[]" with a proper relational link.
/// </summary>
public class CourseInstructor
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public Guid InstructorId { get; set; }
    public Instructor Instructor { get; set; } = null!;
}

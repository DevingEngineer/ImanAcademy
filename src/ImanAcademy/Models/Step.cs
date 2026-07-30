namespace ImanAcademy.Models;

/// <summary>
/// Base class mapped via Table-Per-Hierarchy (TPH). The "StepType" discriminator
/// column plays the same role as the TS discriminated union's "stepType" field.
/// </summary>
public abstract class Step
{
    public Guid Id { get; set; }

    public Guid SubModuleId { get; set; }
    public SubModule SubModule { get; set; } = null!;

    // ----- Metadata (flattened) -----
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int Order { get; set; }
    public int? EstimatedDurationMinutes { get; set; }
    public bool IsFreePreview { get; set; }
    public ContentStatus Status { get; set; }
}

public class ContentStep : Step
{
    public string Body { get; set; } = null!;   // rich text / markdown / HTML
    public ICollection<StepAttachment> Attachments { get; set; } = new List<StepAttachment>();
}

public class VideoStep : Step
{
    public string VideoUrl { get; set; } = null!;
    public int DurationSeconds { get; set; }
    public string? CaptionsUrl { get; set; }
    public string? Transcript { get; set; }
}

public class QuizStep : Step
{
    public int PassingScorePercent { get; set; }
    public bool AllowRetake { get; set; }
    public int? TimeLimitSeconds { get; set; }

    public ICollection<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
}

public class StepAttachment
{
    public Guid Id { get; set; }

    public Guid ContentStepId { get; set; }
    public ContentStep ContentStep { get; set; } = null!;

    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string MimeType { get; set; } = null!;
}

public class QuizQuestion
{
    public Guid Id { get; set; }

    public Guid QuizStepId { get; set; }
    public QuizStep QuizStep { get; set; } = null!;

    public string Prompt { get; set; } = null!;
    public QuestionType Type { get; set; }
    public string? CorrectAnswer { get; set; }   // used only when Type == ShortAnswer
    public int Points { get; set; }

    public ICollection<QuizOption> Options { get; set; } = new List<QuizOption>();
}

public class QuizOption
{
    public Guid Id { get; set; }

    public Guid QuizQuestionId { get; set; }
    public QuizQuestion QuizQuestion { get; set; } = null!;

    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; }   // replaces the TS "correctOptionIds: EntityId[]"
}

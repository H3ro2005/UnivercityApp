namespace Domain.Faculties.Responses;
public sealed class FacultyResponse
{
    public Guid Id { get; set; }
    public Guid? EmployeeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

}

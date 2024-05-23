namespace Models;

public class CreateCourierRequest
{
    public int AdminId { get; set; }
    public required string FullName { get; set; }    
    public required string Email { get; set; }
    public required string Password { get; set; }
}

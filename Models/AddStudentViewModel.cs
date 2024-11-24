
namespace MVCLearning.Web.Models;

public class AddStudentViewModel
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public bool Subscribed { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Task2To6.Model;

public class Team {
    [Key]
    public int Id { get; set; }

    [StringLength(64)]
    public string Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = [];
}

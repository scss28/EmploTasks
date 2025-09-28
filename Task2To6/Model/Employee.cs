using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2To6.Model;

public class Employee {
    [Key]
    public int Id { get; set; }

    [StringLength(64)]
    public string Name { get; set; }

    [Required]
    public virtual Team Team { get; set; }

    [Required]
    public virtual VacationPackage VacationPackage { get; set; }

    public virtual ICollection<Vacation> Vacations { get; set; } = [];

    [ForeignKey(nameof(Team))]
    private int _teamId { get; set; }

    [ForeignKey(nameof(VacationPackage))]
    private int _vacationPackageId { get; set; }
}
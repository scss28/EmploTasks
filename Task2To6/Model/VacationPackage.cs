using System.ComponentModel.DataAnnotations;

namespace Task2To6.Model;

public class VacationPackage {
    [Key]
    public int Id { get; set; }

    [StringLength(64)]
    public string Name { get; set; }

    public int GrantedDays { get; set; }

    public int Year { get; set; }
}
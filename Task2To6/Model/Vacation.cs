using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2To6.Model;

public class Vacation {
    [Key]
    public int Id { get; set; }

    public DateTime DateSince { get; set; }

    public DateTime DateUntil { get; set; }

    [Range(0, int.MaxValue)]
    public int NumberOfHours { get; set; }

    public int IsPartialVacation { get; set; }

    [Required]
    public virtual Employee Employee { get; set; }

    [ForeignKey(nameof(Employee))]
    private int _employeeId { get; set; }

    public int Days {
        get {
            var now = DateTime.Now;
            return ((DateUntil < now ? DateUntil : now) - DateSince).Days + 1; // end inclusive
        }
    }
}

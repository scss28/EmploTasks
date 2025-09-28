using Microsoft.EntityFrameworkCore;

namespace Task2To6;

public class DatabaseContext(DbContextOptions options) : DbContext(options) {
    public DbSet<Model.Employee> Employees { get; set; }
    public DbSet<Model.Team> Teams { get; set; }
    public DbSet<Model.Vacation> Vacations { get; set; }
    public DbSet<Model.VacationPackage> VacationPackages { get; set; }
}

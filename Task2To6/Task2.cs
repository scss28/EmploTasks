using Task2To6.Model;

namespace Task2To6;
public class Task2 {
    // A
    // zwraca listę wszystkich pracowników z zespołu o nazwie “.NET”, którzy mają co
    // najmniej jeden wniosek urlopowy w 2019 roku.
    public static IEnumerable<Employee> A(DatabaseContext db) {
        return db
            .Employees
            .Where(employee => employee.Team.Name == ".NET")
            .Where(employee => employee.Vacations.Any(vacation => vacation.DateSince.Year == 2019 || vacation.DateUntil.Year == 2019));
    }

    public record struct EmployeeUsedVacationDays(Employee Employee, int UsedVacationDays);

    // B
    // zwraca listę pracowników wraz z liczbą dni urlopowych zużytych w bieżącym roku (za
    // dni zużyte uznajemy wszystkie dni we wnioskach urlopowych które są w całości datą
    // przeszłą).
    public static IEnumerable<EmployeeUsedVacationDays> B(DatabaseContext db) {
        var now = DateTime.Now;
        return db
            .Employees
            .Select(employee => new EmployeeUsedVacationDays()
            {
                Employee = employee,
                UsedVacationDays = employee.Vacations.Sum(vacation => vacation.Days),
            });
    }

    // C
    // zwraca listę zespołów w których pracownicy nie złożyli jeszcze żadnego dnia
    // urlopowego w 2019 roku.
    public static IEnumerable<Team> C(DatabaseContext db) {
        return db
            .Teams
            .Where(team => team.Employees.All(
                employee => employee.Vacations.All(vacation => vacation.DateSince.Year != 2019 && vacation.DateUntil.Year != 2019)
            ));
    }
}

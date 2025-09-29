using Task2To6.Model;

namespace Task2To6;
public class Task3 {
    /// <returns>Count of days left in this employee's vacation package. Always >= 0.</returns>
    public static int CountFreeDaysForEmployee(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage) {
        if (vacationPackage.Id != employee.VacationPackage.Id) throw new ArgumentException("Invalid vacation package for this employee.");

        var currentYear = DateTime.Now.Year;
        var daySum = 0;
        foreach (var vacation in vacations) {
            if (vacation.Employee.Id != employee.Id || vacation.DateSince.Year != currentYear) continue;
            daySum += vacation.Days;
        }

        return Math.Max(0, vacationPackage.GrantedDays - daySum);
    }
}

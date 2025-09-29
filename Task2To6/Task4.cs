using Task2To6.Model;

namespace Task2To6;
public class Task4 {
    public static bool IfEmployeeCanRequestVacation(Employee employee, List<Vacation> vacations, VacationPackage vacationPackage) {
        return Task3.CountFreeDaysForEmployee(employee, vacations, vacationPackage) > 0;
    }
}

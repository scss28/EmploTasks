using Task2To6;
using Task2To6.Model;

namespace Task2To6Tests;
public class Task5Tests {
    [Test]
    public void EmployeeCanRequestVacation() {
        var vacationPackage = new VacationPackage
        {
            Name = "Standard 2025",
            GrantedDays = 20,
            Year = 2025
        };

        var vacation = new Vacation()
        {
            DateSince = new DateTime(2025, 3, 10),
            DateUntil = new DateTime(2025, 3, 20),
        };

        List<Vacation> vacations = [vacation];

        var employee = new Employee()
        {
            Id = 0,
            VacationPackage = vacationPackage,
            Vacations = vacations,
        };

        vacation.Employee = employee;

        Assert.That(Task4.IfEmployeeCanRequestVacation(employee, vacations, vacationPackage), Is.True);
    }

    [Test]
    public void EmployeeEantRequestVacation() {
        var vacationPackage = new VacationPackage
        {
            Name = "Standard 2025",
            GrantedDays = 20,
            Year = 2025
        };

        var vacation = new Vacation()
        {
            DateSince = new DateTime(2025, 3, 10),
            DateUntil = new DateTime(2025, 3, 30),
        };

        List<Vacation> vacations = [vacation];

        var employee = new Employee()
        {
            Id = 0,
            VacationPackage = vacationPackage,
            Vacations = vacations,
        };

        vacation.Employee = employee;

        Assert.That(Task4.IfEmployeeCanRequestVacation(employee, vacations, vacationPackage), Is.False);
    }
}

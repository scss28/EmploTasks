using Microsoft.EntityFrameworkCore;
using Task2To6;
using Task2To6Tests;

namespace Task2Tests;

public class Task3Tests {
    DatabaseContext _db;

    [Test]
    public void Test() {
        var john = _db.Employees
            .Include(employee => employee.Vacations)
            .Include(employee => employee.VacationPackage)
            .First(employee => employee.Name == "John .NET");
        var johnLeftDays = Task3.CountFreeDaysForEmployee(john, [.. john.Vacations], john.VacationPackage);

        Assert.That(johnLeftDays, Is.EqualTo(20));
    }

    [OneTimeSetUp]
    public void Setup() {
        _db = TestHelper.SampleDb;
    }

    [OneTimeTearDown]
    public void TearDown() {
        _db.Dispose();
    }
}
using Task2To6;
using Task2To6Tests;

namespace Task2Tests;

public class Task3Tests {
    DatabaseContext _db;

    [Test]
    public void Test() {
        var john = _db.Employees.First(employee => employee.Name == "John .NET");
        var johnLeftDays = Task3.CountFreeDaysForEmployee(john, [.. john.Vacations], john.VacationPackage);

        Assert.That(johnLeftDays, Is.EqualTo(13));
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
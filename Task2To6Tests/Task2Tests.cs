using Task2To6;
using Task2To6Tests;

namespace Task2Tests;

public class Task2Tests {
    DatabaseContext _db;

    [Test]
    public void Task2A() {
        var result = Task2.A(_db).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(result, Has.Length.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("John .NET"));
        });
    }

    [Test]
    public void Task2B() {
        var result = Task2.B(_db);
        Assert.Multiple(() =>
        {
            Assert.That(result.First(data => data.Employee.Name == "John .NET").UsedVacationDays, Is.EqualTo(7));
            Assert.That(result.First(data => data.Employee.Name == "Alice Dev").UsedVacationDays, Is.EqualTo(10));
            Assert.That(result.First(data => data.Employee.Name == "Bob HR").UsedVacationDays, Is.EqualTo(6));
        });
    }

    [Test]
    public void Task2C() {
        var result = Task2.C(_db).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(result.FirstOrDefault(team => team.Name == ".NET"), Is.Null);
            Assert.That(result.Length, Is.EqualTo(2));
        });
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
using Task1;

namespace Task1Tests;

public class EmployeeStructureTests {
    Employee[] _employees;

    [Test]
    public void GetSuperiorRowOfEmployeeReturnsCorrectRowNumbers() {
        var structure = EmployeeStructure.Fill(_employees);

        var row1 = structure.GetSuperiorRowOfEmployee(2, 1);
        var row2 = structure.GetSuperiorRowOfEmployee(4, 3);
        var row3 = structure.GetSuperiorRowOfEmployee(4, 1);

        Assert.Multiple(() =>
        {
            Assert.That(row1, Is.EqualTo(1));
            Assert.That(row2, Is.Null);
            Assert.That(row3, Is.EqualTo(2));
        });
    }

    [SetUp]
    public void Setup() {
        _employees = [
            new() {
                Id = 1,
                Name = "Jan Kowalski",
                SuperiorId = null,
            },
            new() {
                Id = 2,
                Name = "Kamil Nowak",
                SuperiorId = 1,
            },
            new() {
                Id = 3,
                Name = "Anna Mariacka",
                SuperiorId = 1,
            },
            new() {
                Id = 4,
                Name = "Andrzej Abacki",
                SuperiorId = 2,
            },
        ];
    }
}

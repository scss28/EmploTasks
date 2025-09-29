using Microsoft.EntityFrameworkCore;
using Task2To6;
using Task2To6.Model;

namespace Task2To6Tests;
internal static class TestHelper {
    public static DatabaseContext SampleDb {
        get {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase("TestDb")
                .Options;

            var db = new DatabaseContext(options);

            // Teams
            var netTeam = new Team { Name = ".NET" };
            var devTeam = new Team { Name = "Development" };
            var hrTeam = new Team { Name = "Human Resources" };

            db.Teams.AddRange(netTeam, devTeam, hrTeam);

            // Vacation Packages
            var pkg2019 = new VacationPackage
            {
                Name = "Standard 2019",
                GrantedDays = 20,
                Year = 2019
            };

            var pkg2025 = new VacationPackage
            {
                Name = "Standard 2025",
                GrantedDays = 20,
                Year = 2025
            };

            db.VacationPackages.AddRange(pkg2019, pkg2025);

            // Employees
            var john = new Employee
            {
                Name = "John .NET",
                Team = netTeam,
                VacationPackage = pkg2019,
            };

            var alice = new Employee
            {
                Name = "Alice Dev",
                Team = devTeam,
                VacationPackage = pkg2025
            };

            var bob = new Employee
            {
                Name = "Bob HR",
                Team = hrTeam,
                VacationPackage = pkg2025
            };

            db.Employees.AddRange(john, alice, bob);

            // Vacations
            var johnVacation2019 = new Vacation
            {
                DateSince = new DateTime(2019, 6, 1),
                DateUntil = new DateTime(2019, 6, 7),
                NumberOfHours = 40,
                IsPartialVacation = 0,
                Employee = john
            };

            var aliceVacation2025 = new Vacation
            {
                DateSince = new DateTime(2025, 5, 1),
                DateUntil = new DateTime(2025, 5, 10),
                NumberOfHours = 80,
                IsPartialVacation = 0,
                Employee = alice
            };

            var bobVacation2025 = new Vacation
            {
                DateSince = new DateTime(2025, 7, 15),
                DateUntil = new DateTime(2025, 7, 20),
                NumberOfHours = 40,
                IsPartialVacation = 1,
                Employee = bob
            };

            db.Vacations.AddRange(johnVacation2019, aliceVacation2025, bobVacation2025);
            db.SaveChanges();

            return db;
        }
    }
}

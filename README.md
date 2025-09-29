# Opis
Zadanie pierwsze znajduje się w projekcie `Task1` i testy do tego zadania w `Task1Tests`. Reszta zadań jest w `Task2To6` ze względu na to że dzielą ze sobą `DBContext`, testy analogicznie znajdują się w `Task2To6Tests`.

# Task 6
Metoda w zadaniu 3 może być zainplmenetowana bez pobierania z bazy danych wszystkich `vacations`, jeżeli znamy ID danego 'employee' lub mamy jego instancje można stworzyć LINQ query w ten sposób:
```C#
var employee = db
  .Employees
  .Include(employee => employee.Vacations)
  .Include(employee => employee.VacationPackage)
  .Single(employee => employee.Id == employeeId);

var currentYear = DateTime.Now.Year;
var daySum = employee
  .Vacations
  .Where(vacation => vacation.DateSince.Year == currentYear)
  .Sum(vacation => ((vacation.DateUntil < DateTime.Now ? vacation.DateUntil : DateTime.Now) - vacation.DateSince).Days + 1);

return Math.Max(0, employee.VacationPackage.GrantedDays - daySum);
```
W tym wypadku używamy tylko `vacations` związanych z danym `employee` i sumujemy dni w bazie danych.

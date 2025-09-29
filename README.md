# Opis
Zadanie pierwsze znajduje się w projekcie `Task1` i testy do tego zadania w `Task1Tests`. Reszta zadań jest w `Task2To6` ze względu na to że dzielą ze sobą `DBContext`, testy analogicznie znajdują się w `Task2To6Tests`.

# Task 6
Metoda w zadaniu 3 może być w pełni zainplmenetowana za pomocą jednego LINQ lub SQL query, jeżeli znamy ID danego 'employee' lub mamy jego instancje. 
```C#
var daySum = db
  .Employees
  .Find(employeeId)
  .Vacations
  .Where(vacation => vacation.DateSince.Year != currentYear)
  .Sum(vacation => ((vacation.DateUntil < DateTime.Now ? vacation.DateUntil : DateTime.Now) - vacation.DateSince).Days + 1);
```

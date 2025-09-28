namespace Task1;

using Structure = Dictionary<(int superiorId, int employeeId), int>;

public struct EmployeeStructure {
    Structure _structure;

    /// <summary>
    /// Creates an <see cref="EmployeeStructure"/> based on provided employees.
    /// </summary>
    /// <exception cref="InvalidOperationException">If some employee has an invalid `superiorId`.</exception>
    public static EmployeeStructure Fill(IEnumerable<Employee> employees) {
        var structure = new Structure();

        // To avoid unnecessary reallocations inside the loop `ids` is declared outside and cleared each iteration.
        var ids = new List<int>(64);

        foreach (var employee in employees) {
            var currentEmployee = employee;
            while (currentEmployee.SuperiorId is { } superiorId) {
                ids.Add(currentEmployee.Id);
                for (var i = 0; i < ids.Count; i += 1) {
                    structure[(superiorId, ids[i])] = ids.Count - i;
                }

                currentEmployee = employees.First(employee => employee.Id == superiorId);
            }

            ids.Clear();
        }

        return new() { _structure = structure };
    }

    /// <returns>The row depth between employee and superior.</returns>
    public readonly int? GetSuperiorRowOfEmployee(int employeeId, int superiorId) {
        if (!_structure.TryGetValue((superiorId, employeeId), out var row)) return null;
        return row;
    }
}


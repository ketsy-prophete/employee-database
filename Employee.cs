public class Employee
{
    protected string? fullName;

    protected string? employeeTitle;

    protected string? employeeDate;

    public string? employeeID;

    public virtual void PrintDetails()
    {
        Console.WriteLine(fullName + ", " + employeeTitle);
        Console.WriteLine($"Employee ID: {employeeID}");
        Console.WriteLine($"Start Date: {employeeDate}");
    }

    public Employee(string flName, string empTitle, string empID, string empDate)
    {
        fullName = flName;
        employeeTitle = empTitle;
        employeeID = empID;
        employeeDate = empDate;
    }

    public string? GetFullName()
    {
        return fullName;
    }

    public string? GetEmployeeTitle()
    {
        return employeeTitle;
    }

    public string? GetEmployeeID()
    {
        return employeeID;
    }

    public string? GetEmployeeDate()
    {
        return employeeDate;
    }
}

// Improvements to above code, there would need to be changes applied to program.cs to make this work.
// using System.Dynamic;

// public class Employee
// {
//     public string FullName { get; protected set; }
//     public string EmployeeID { get; protected set; }
//     public string EmployeeTitle { get; protected set; }
//     public string EmployeeDate { get; protected set; }

//     public Employee(string fullName, string employeeID, string employeeTitle, string employeeDate)
//     {
//         FullName = fullName;
//         EmployeeID = employeeID;
//         EmployeeTitle = employeeTitle;
//         EmployeeDate = employeeDate;
//     }

//     public void PrintDetails()
//     {
//         Console.WriteLine(FullName + ", " + EmployeeTitle);
//         Console.WriteLine($"Employee ID: {EmployeeID}");
//         Console.WriteLine($"Start Date: {EmployeeDate}");
//     }

//     public void SetFullName(string fullName) => FullName = fullName;
//     public void SetEmployeeID(string employeeID) => EmployeeID = employeeID;
//     public void SetEmployeeTitle(string employeeTitle) => EmployeeTitle = employeeTitle;
//     public void SetEmployeeDate(string employeeDate) => EmployeeDate = employeeDate;
// }
using System.Text.RegularExpressions;
List<Employee> employeeList = new List<Employee>();

string[] textLine = File.ReadAllLines("Employees.txt");
foreach (string line in textLine)
{
    EmployeeListString(line);
}

bool continueProgram = true;
while (continueProgram)
{
    Console.WriteLine("\n");

    DisplayOptions();

    Console.Write("_________________\nMAIN MENU -- Enter your choice: #");
    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            Console.WriteLine(CreateEmployee());
            break;
        case "2":
            Console.WriteLine("\n");
            Console.Write("VIEWING CURRENT EMPLOYEES...\n");
            Console.WriteLine("\n");
            ViewEmployees();
            break;
        case "3":
            Console.WriteLine("\n");
            Console.Write("HOW WOULD YOU LIKE TO SEARCH?\n");
            SearchEmployees();
            break;
        case "4":
            Console.WriteLine(DeleteEmployee(employeeList));

            break;
        case "5":
            Console.Write("Employees Saved. Goodbye!");
            continueProgram = false;
            break;
        default:
            Console.WriteLine("\n");
            Console.WriteLine($"---- Please select from the above options (1-5) ----");
            break;
    }
}

void DisplayOptions()
{
    string optionList1 = "_________________\n\n1) Create New Employee\n2) View All Employees\n3) Search Employees\n4) Delete Employee\n5) Quit";
    Console.WriteLine(optionList1);
}

string CreateEmployee()
{
    string fullName = "";
    while (true)
    {
        Console.Write("What is the employee's first and last name? ");
        fullName = Console.ReadLine() ?? "";

        if (fullName.Contains(' '))
        {
            break;
        }
        else
        {
            Console.WriteLine("\n");
            Console.Write("---- Please enter both first and last name for each employee. ----");
            Console.WriteLine("\n");
        }
    }

    Console.Write("What is the employee's title? ");
    string employeeTitle = Console.ReadLine() ?? "";

    string employeeDate = "";
    string dateEntry = "";
    while (true)
    {
        Console.Write("What is the employee's start date (dd/mm/yyyy)? ");
        dateEntry = Console.ReadLine() ?? "";

        string pattern = @"^\d{1,2}/\d{1,2}/\d{4}$";

        if (Regex.IsMatch(dateEntry, pattern))
        {
            employeeDate = dateEntry;
            break;
        }
        else
        {
            Console.WriteLine("\n");
            Console.Write($"---- Please enter valid date format. ----");
            Console.WriteLine("\n");
        }
    }

    System.Random random = new System.Random();
    int generateID = random.Next(1000, 9999);
    string employeeID = generateID.ToString();


    Employee newEmployee = new Employee(fullName, employeeTitle, employeeID, employeeDate);
    employeeList.Add(newEmployee);
    Console.WriteLine("\n");
    string message = $"Welcome Aboard {fullName.ToUpper()}! - Employee ID: {employeeID}";

    return message;
}

void ViewEmployees()
{
    foreach (Employee employee in employeeList)
    {
        employee.PrintDetails();
        Console.WriteLine("\n");

    }
}

void SearchEmployees()
{
    string optionList2 = "SEARCH BY...\n\n1) Employee ID?\n2) Name?";
    Console.WriteLine(optionList2);
    Console.Write("_________________\nEnter Selection: #");
    string choice = Console.ReadLine() ?? "";

    if (choice == "1")
    {
        Console.Write("Enter Employee ID: ");
        string searchID = Console.ReadLine() ?? "";
        Console.WriteLine("\n");


        Employee foundID = employeeList.Find(e => e.GetEmployeeID() == searchID);
        if (foundID != null)
        {
            Console.WriteLine("---- RESULTS ----");
            foundID.PrintDetails();
        }
    }
    if (choice == "2")
    {
        Console.Write("Enter a Name: ");
        string searchName = Console.ReadLine() ?? "";
        Console.WriteLine("\n");

        string matchName = searchName.ToLower();
        List<Employee> matchingEmployees = employeeList.FindAll(e => e.GetFullName().ToLower().Contains(matchName));

        if (matchingEmployees.Count > 0)
        {
            Console.WriteLine("---- RESULTS ----");
            foreach (Employee employee in matchingEmployees)
            {
                employee.PrintDetails();
                Console.WriteLine("\n");
            }
        }
    }
}

string DeleteEmployee(List<Employee> employeeList)
{
    Console.Write("Enter Employee ID to delete: ");
    string idSearch = Console.ReadLine() ?? "";

    List<Employee> matchingEmployeeID = employeeList.FindAll(e => e.employeeID.Contains(idSearch));

    if (matchingEmployeeID.Count == 0)
    {
        Console.WriteLine("\n");
        return $"---- Employee with ID \"{idSearch}\" not found or invalid. ----";
    }
    else
    {
        foreach (Employee employee in matchingEmployeeID)
        {
            employeeList.Remove(employee);
            Console.WriteLine("\n");
            Console.WriteLine($"Employee with ID {employee.employeeID} has been deleted.");
        }
        return " ";
    }
}

string[] employeeListString()
{
    List<string> stringgedEmployees = new List<string>();

    foreach (Employee employee in employeeList)
    {
        string employeeString = $"{employee.GetFullName()}, {employee.GetEmployeeTitle()}, {employee.GetEmployeeID()}, {employee.GetEmployeeDate()}";
        stringgedEmployees.Add(employeeString);
    }
    return stringgedEmployees.ToArray();
}

void EmployeeListString(string finalEmployeeString)
{
    string[] employeeObj = finalEmployeeString.Split(",");
    if (employeeObj.Length >= 4)
    {
        string fullName = employeeObj[0].Trim();
        string employeeTitle = employeeObj[2].Trim();
        string employeeID = employeeObj[1].Trim();
        string employeeDate = employeeObj[3].Trim();
        Employee newEmployee = new Employee(fullName, employeeTitle, employeeID, employeeDate);
        employeeList.Add(newEmployee);
    }
    else
    {
        Console.WriteLine($"Invalid employee data: {finalEmployeeString}");
    }
}

string[] employeesToWrite = employeeListString();
File.WriteAllLines("Employees.txt", employeesToWrite);
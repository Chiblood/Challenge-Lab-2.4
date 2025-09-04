class Menu
{
    /// <summary> Displays the main menu and processes user choices.</summary>
    /// <returns>True if the program should continue, false otherwise.</returns>
    public static bool MainMenu()
    {
        Console.WriteLine($"\n--- Main Menu ---");
        Console.WriteLine("1. Add New Student");
        Console.WriteLine("2. View Existing Students (work in progress)");
        Console.WriteLine("3. Add Grades to Student");
        Console.WriteLine("4. Exit");
        int choice = GetUserInput<int>("Enter your choice: ", "Invalid input. Please enter a whole number.");

        switch (choice)
        {
            case 1: // AddNewStudent();
                AddNewStudent();
                break;
            case 2: // ExistingUser, read from list and print to console
                ViewStudents();
                break;
            case 3: // Add grades to student
                AddGradesToStudent();
                break;
            case 4: // Exit
                Console.WriteLine("Exiting the program. Goodbye!");
                return false;
            default:
                Console.WriteLine("Invalid choice. Please select a valid option.");
                break;
        }
        return true;
    }
    // Input validation methods

    /// <summary> Prompts the user for input and ensures a non-empty string is returned.</summary>
    /// <param name="prompt">The message to display to the user.</param>
    /// <returns>A non-null, non-whitespace string from the user.</returns>
    public static string GetRequiredString(string prompt)
    {
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    /// <summary> Prompts the user for input, validates it, and converts it to the specified type `T`.
    /// See https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics for more details.
    /// </summary>
    /// <typeparam name="T">The desired type (e.g., int, decimal, double), which must be parsable.</typeparam>
    /// <param name="prompt">The message to display to the user.</param>
    /// <param name="parseErrorMessage">An optional custom error message to display on parsing failure.</param>
    /// <returns>A valid value of type `T` from the user.</returns>
    public static T GetUserInput<T>(string prompt, string? parseErrorMessage = null) where T : IParsable<T>
    {
        T? value;

        while (!T.TryParse(GetRequiredString(prompt), null, out value))// Calls GetUserInput() to get the raw user input first.
        {
            Console.WriteLine(parseErrorMessage ?? $"Invalid input. Please enter a valid {typeof(T).Name}.");
        }
        return value;
    }

    public static void AddNewStudent() // Handles the logic for adding a new student.
    {
        Console.WriteLine("Add New Student selected.");
        int studentID = GetUserInput<int>("Enter Student ID: ", "Invalid input. Please enter a whole number.");
        string firstName = GetRequiredString("Enter First Name: ");
        string lastName = GetRequiredString("Enter Last Name: ");
        Student newStudent = new(studentID, firstName, lastName);
        newStudent.ReportCard();
        newStudent.SaveStudent();
        Console.WriteLine($"New student {newStudent.FullName} added successfully.");
    }
    public static void ViewStudents()
    {
        Console.WriteLine("View Existing Students selected.");
        foreach (var student in Student.StudentsList)
        {
            student.ReportCard();
        }
    }
    public static void AddGradesToStudent()
    {
        Console.WriteLine("Add Grades to Student selected.");
        int studentID = GetUserInput<int>("Enter Student ID: ");
        var student = Student.StudentsList.FirstOrDefault(s => s.StudentID == studentID);
        if (student == null)
        {
            Console.WriteLine($"No student found with ID {studentID}.");
            return;
        }
        string subjectName = GetRequiredString("Enter Subject Name: ");
        decimal score = GetUserInput<decimal>("Enter Score: ", "Invalid input. Please enter a valid decimal number.");
        student.AddGrade(subjectName, score);
        Console.WriteLine($"Added grade {score} for subject {subjectName} to student {student.FullName}.");
    }
}
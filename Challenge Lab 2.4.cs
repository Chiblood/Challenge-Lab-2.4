/* Challenge Lab 2.4
4. Write a C# Sharp program to read roll no, name and marks of three subjects and calculate the total, percentage and division. (May use a struct / class to represent the student)
    Test Data :
    Input the Roll Number of the student :784
    Input the Name of the Student :James
    Input the marks of Physics, Chemistry and Computer Application : 70 80 90
    Expected Output :
    Roll No : 784
    Name of Student : James
    Marks in Physics : 70
    Marks in Chemistry : 80
    Marks in Computer Application : 90
    Total Marks = 240
    Percentage = 80.00
    Division = First
*/
namespace Challenge_Lab_2._4
{
    public class Program
    {
        /// <summary> Prompts the user for input and ensures a non-empty string is returned.</summary>
        /// <param name="prompt">The message to display to the user.</param>
        /// <returns>A non-null, non-whitespace string from the user.</returns>
        private static string GetRequiredString(string prompt)
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
        /// See https://learn.microsoft.com/en-us/aspnet/core/blazor/components/generic-type-support?view=aspnetcore-9.0 for more details.
        /// </summary>
        /// <typeparam name="T">The desired type (e.g., int, decimal, double), which must be parsable.</typeparam>
        /// <param name="prompt">The message to display to the user.</param>
        /// <param name="parseErrorMessage">An optional custom error message to display on parsing failure.</param>
        /// <returns>A valid value of type `T` from the user.</returns>
        private static T GetUserInput<T>(string prompt, string? parseErrorMessage = null) where T : IParsable<T>
        {
            T? value;

            while (!T.TryParse(GetRequiredString(prompt), null, out value))// Calls GetUserInput() to get the raw user input first.
            {
                Console.WriteLine(parseErrorMessage ?? $"Invalid input. Please enter a valid {typeof(T).Name}.");
            }
            return value;
        }

        public static void Main(string[] args)
        {
            Student student = new Student
            {
                RollNumber = GetUserInput<int>("Input the Roll Number of the student: ", "Please enter a valid whole number."),
                Name = GetRequiredString("Input the Name of the Student: "),
                PhysicsMarks = GetUserInput<int>("Input the marks of Physics: ", "Please enter a valid whole number."),
                ChemistryMarks = GetUserInput<int>("Input the marks of Chemistry: ", "Please enter a valid whole number."),
                ComputerApplicationMarks = GetUserInput<int>("Input the marks of Computer Application: ", "Please enter a valid whole number.")
            };
            Console.WriteLine($"\n--- Student Report ---");
            Console.WriteLine($"Roll No: {student.RollNumber}");
            Console.WriteLine($"Name of Student: {student.Name}");
            Console.WriteLine($"Marks in Physics: {student.PhysicsMarks}");
            Console.WriteLine($"Marks in Chemistry: {student.ChemistryMarks}");
            Console.WriteLine($"Marks in Computer Application: {student.ComputerApplicationMarks}");
            Console.WriteLine($"Total Marks = {student.TotalMarks}");
            Console.WriteLine($"Percentage = {student.Percentage}");
            Console.WriteLine($"Division = {student.Division}");
        }
    }
}
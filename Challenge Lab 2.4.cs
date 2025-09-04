/* Challenge Lab 2.4
Write a C# Sharp program to take user input for the following:
    Student ID, Student Name, and other student info. Grades for different subjects.
Calculate the GPA of the student and class percentile based on the grades entered.

OBJECT Student1 : of class Students
    Properties : StudentID, Name
    Methods : AddGrade(SubjectName, Score), ReportCard()
OBJECT Grades
    Properties : TotalGPA, SubjectName, Score
    Methods : AddGrade(SubjectName, Score)
*/
namespace Challenge_Lab_2._4
{
    public class Program
    {

        public static void Main(string[] args)
        {
            // Test Data
            Student John = new(1, "John", "Devries");
            John.AddGrade("Math", 90);
            John.AddGrade("Physics", 85);
            John.AddGrade("Computer Application", 95);
            John.SaveStudent();


            Student Jane = new(2, "Jane", "Smith");
            Jane.AddGrade("Math", 80);
            Jane.AddGrade("Physics", 75);
            Jane.AddGrade("Computer Application", 85);
            Jane.SaveStudent();

            Student Jim = new(3, "Jim", "Brown");
            Jim.AddGrade("Math", 70);
            Jim.AddGrade("Physics", 65);
            Jim.AddGrade("Computer Application", 75);
            Jim.SaveStudent();

            // Main Menu
            while (Menu.MainMenu()) { }
        }
    }
}
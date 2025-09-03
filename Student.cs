/* Challenge Lab 2.4
4. Write a C# Sharp program to read roll no, name and marks of three subjects and calculate the total, percentage and division. (Use a struct / class to represent the student)
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
class Student
{
    public int RollNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public int PhysicsMarks { get; set; }
    public int ChemistryMarks { get; set; }
    public int ComputerApplicationMarks { get; set; }

    public int TotalMarks => PhysicsMarks + ChemistryMarks + ComputerApplicationMarks;

    public decimal Percentage => TotalMarks / 3;

    public string Division
    {
        get
        {
            if (Percentage >= 60) return "First";
            if (Percentage >= 50) return "Second";
            if (Percentage >= 40) return "Third";
            return "Fail";
        }
    }
}
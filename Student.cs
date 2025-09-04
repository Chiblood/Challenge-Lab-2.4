
class Student
{
    // This static list will hold all student objects created during the program's run.
    public static List<Student> StudentsList { get; } = new();

    public int StudentID { get; set; }
    public int TeacherID { get; set; } = 1; // default TeacherID for simplicity
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}".Trim();
    public List<Grade> StudentGrades { get; } = new List<Grade>();

    // Constructor to initialize a student with ID, first name, and last name.
    public Student(int studentID, string firstName, string lastName)
    {
        StudentID = studentID;
        FirstName = firstName;
        LastName = lastName;
        StudentsList.Add(this);
    }

    public decimal GPA
    {
        get
        {
            if (StudentGrades.Count == 0) return 0m;
            return StudentGrades.Average(g => g.Score);
        }
    }

    public string ClassPercentile // Note: This is a simplified percentile calculation for demonstration purposes.
    {
        get
        {
            var studentGPA = GPA;
            if (studentGPA == 0) return "N/A"; // No grades yet
            if (studentGPA == 100) return "100%"; // Perfect score
            if (studentGPA < 0 || studentGPA > 100) return "Invalid GPA"; // Invalid GPA
            if (studentGPA > 90 && studentGPA <= 100) return "Top 10%"; // Top 10%
            if (studentGPA > 80 && studentGPA <= 90) return "Top 20%"; // Top 20%
            if (studentGPA > 70 && studentGPA <= 80) return "Top 30%"; // Top 30%
            if (studentGPA > 60 && studentGPA <= 70) return "Top 40%"; // Top 40%
            if (studentGPA > 50 && studentGPA <= 60) return "Top 50%"; // Top 50%
            if (studentGPA > 40 && studentGPA <= 50) return "Top 60%"; // Top 60%
            if (studentGPA > 30 && studentGPA <= 40) return "Top 70%"; // Top 70%
            if (studentGPA > 20 && studentGPA <= 30) return "Top 80%"; // Top 80%
            if (studentGPA > 10 && studentGPA <= 20) return "Top 90%"; // Top 90%
            return "Bottom 10%"; // Bottom 10%
        }
    }
    public void AddGrade(string subjectName, decimal score)
    {
        var newGrade = new Grade
        {
            StudentID = this.StudentID,
            // The GradeID should be unique for the student. Basing it on the current count is a simple approach.
            GradeID = this.StudentGrades.Count + 1,
            SubjectName = subjectName,
            Score = score
        };
        this.StudentGrades.Add(newGrade); // This adds the grade to the specific student's list of grades.
    }
    public void ReportCard()
    {
        Console.WriteLine($"\n--- Student Report ---");
        Console.WriteLine($"Roll No: {StudentID}");
        Console.WriteLine($"Name of Student: {FullName}");
        Console.WriteLine($"GPA = {GPA}");
        Console.WriteLine($"Class Percentile = {ClassPercentile}");
    }
    public void SaveStudent()
    {
        try
        {
            // Get the base directory where the application is running.
            string exePath = AppContext.BaseDirectory;
            string saveDataPath = Path.Combine(exePath, "SaveData");
            Directory.CreateDirectory(saveDataPath); // This ensures the directory exists.

            Console.WriteLine($"Your student's data will be saved in: {saveDataPath}");
            // Create a file name based on the student's name.
            string baseName = FullName.Replace(" ", "_");
            string suffix = "_StudentData.txt";
            // This logic prevents adding the suffix if it's already there.
            if (baseName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
            {
                baseName = baseName.Substring(0, baseName.Length - suffix.Length);
            }
            string fileName = $"{baseName}{suffix}";
            string fullPath = Path.Combine(saveDataPath, fileName);

            using (StreamWriter writer = new(fullPath))
            {
                writer.WriteLine($"Student ID: {StudentID}");
                writer.WriteLine($"Teacher ID: {TeacherID}");
                writer.WriteLine($"First Name: {FirstName}");
                writer.WriteLine($"Last Name: {LastName}");
                writer.WriteLine($"GPA: {GPA:F2}"); // Format GPA for consistency
                writer.WriteLine($"Class Percentile: {ClassPercentile}");
                // Save each grade
                writer.WriteLine("Grades:");
                foreach (var grade in StudentGrades)
                {
                    writer.WriteLine($"  Subject: {grade.SubjectName}, Score: {grade.Score}, Date: {grade.GradeDate:yyyy-MM-dd}");
                }
            }
            Console.WriteLine($"Student data saved to: {fullPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving student data: {ex.Message}");
        }
    }
}
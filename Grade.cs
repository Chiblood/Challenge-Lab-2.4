class Grade
{
    public int GradeID { get; set; } // Primary key for the Grade (Primary Keys should be unique and the first property in the class)
    public int StudentID { get; set; } // The foreign key linking to the Students class
    public string SubjectName { get; set; } = string.Empty;
    public decimal Score { get; set; }
    public DateTime GradeDate { get; set; } = DateTime.Now;
}
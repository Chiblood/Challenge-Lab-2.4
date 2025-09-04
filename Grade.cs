class Grade
{
    public int StudentID { get; set; } // the foreign key linking to the Students class
    public int GradeID { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public decimal Score { get; set; }
    public DateTime GradeDate { get; set; } = DateTime.Now;
}
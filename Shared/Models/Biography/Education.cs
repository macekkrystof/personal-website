namespace PersonalWebsite.Shared.Models
{
    public class Education
    {
        public string SchoolName { get; set; }

        public string FacultyName { get; set; }
        
        public string Course { get; set; }

        public string EducationType { get; set; }

        public MonthAndYear MonthAndYearFrom { get; set; }
        
        public MonthAndYear MonthAndYearTo { get; set; }
    }
}
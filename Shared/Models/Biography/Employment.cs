namespace PersonalWebsite.Shared.Models.Biography
{
    public class Employment
    {
        public string PositionTitle { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public MonthAndYear MonthAndYearFrom { get; set; }
        
        public MonthAndYear MonthAndYearTo { get; set; }

        public string CompanyLogoUrl { get; set; }
    }
}
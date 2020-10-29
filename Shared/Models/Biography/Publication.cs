namespace PersonalWebsite.Shared.Models
{
    public class Publication
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public MonthAndYear? MonthAndYear { get; set; }
    }
}
namespace Shared.Models.Biography
{
    public class Certificate
    {
        public string Name { get; set; }

        public string IssuedBy { get; set; }

        public MonthAndYear Issued { get; set; }

        public MonthAndYear ValidUntil { get; set; }

        public string Link { get; set; }
    }
}
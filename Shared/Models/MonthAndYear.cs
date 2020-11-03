namespace PersonalWebsite.Shared.Models
{
    public struct MonthAndYear
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Month}/{Year}";
        }
    }
}
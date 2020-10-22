namespace Shared.Models.Biography
{
    public class Language
    {
        public string Name { get; set; }

        public LanguageKnowledgeLevel Level { get; set; }
    }
    
    public enum LanguageKnowledgeLevel  {
        A1,
        A2,
        B1,
        B2,
        C1,
        C2
    }
}
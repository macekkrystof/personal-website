using System.Collections.Generic;

namespace Shared.Models.Biography
{
    public class Biography
    {
        public string LanguageCode { get; set; }

        public string AvatarLink { get; set; }

        public string BasicInfoTitle { get; set; }

        public BasicInfo BasicInfo { get; set; }

        public string EmploymentsTitle { get; set; }

        public List<Employment> Employments { get; set; }

        public string EducationsTitle { get; set; }

        public List<Education> Educations { get; set; }

        public string SkillsTitle { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
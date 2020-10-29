using System;
using System.Collections.Generic;

namespace PersonalWebsite.Shared.Models
{
    public class Biography
    {
        public Guid Id { get; set; }
        public string LanguageCode { get; set; }

        public string AvatarLink { get; set; }

        public string BasicInfoTitle { get; set; }

        public BasicInfo BasicInfo { get; set; }

        public SocialMedia SocialMedia { get; set; }

        public string EmploymentsTitle { get; set; }

        public List<Employment> Employments { get; set; }

        public string EducationsTitle { get; set; }

        public List<Education> Educations { get; set; }

        public string SkillsTitle { get; set; }

        public List<Skill> Skills { get; set; }

        public string VolunteeringActivitiesTitle { get; set; }

        public List<Employment> VolunteeringActivities { get; set; }

        public string CertificatesTitle { get; set; }

        public List<Certificate> Certificates { get; set; }

        public string PublicationsTitle { get; set; }

        public List<Publication> Publications { get; set; }

        public string HobbiesTitle { get; set; }

        public List<string> Hobbies { get; set; }

    }
}
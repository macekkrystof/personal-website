using Shared.Models.Biography;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Microsoft.Azure.Cosmos.Table;

namespace PersonalWebsite.Api.Models
{
    internal class BiographyTableModel : TableEntity
    {

        public BiographyTableModel()
        {
            
        }
        public BiographyTableModel(Biography biography)
        {
            RowKey = biography.Id.ToString();
            LanguageCode = biography.LanguageCode;
            AvatarLink = biography.AvatarLink;
            BasicInfoTitle = biography.BasicInfoTitle;
            BasicInfo = JsonConvert.SerializeObject(biography.BasicInfo);
            EmploymentsTitle = biography.EmploymentsTitle;
            Employments = JsonConvert.SerializeObject(biography.Employments);
            EducationsTitle = biography.EducationsTitle;
            Educations = JsonConvert.SerializeObject(biography.Educations);
            SkillsTitle = biography.SkillsTitle;
            Skills = JsonConvert.SerializeObject(biography.Skills);
            VolunteeringActivitiesTitle = biography.VolunteeringActivitiesTitle;
            VolunteeringActivities = JsonConvert.SerializeObject(biography.VolunteeringActivities);
            CertificatesTitle = biography.CertificatesTitle;
            Certificates = JsonConvert.SerializeObject(biography.Certificates);
            PublicationsTitle = biography.PublicationsTitle;
            Publications = JsonConvert.SerializeObject(biography.Publications);
            HobbiesTitle = biography.HobbiesTitle;
            Hobbies = JsonConvert.SerializeObject(biography.Hobbies);
        }
        public Biography GetBiography()
        {
            return new Biography
            {
                Id = Guid.Parse(RowKey),
                BasicInfoTitle = this.BasicInfoTitle,
                BasicInfo = JsonConvert.DeserializeObject<BasicInfo>(this.BasicInfo),
                EmploymentsTitle = this.EmploymentsTitle,
                Employments = JsonConvert.DeserializeObject<List<Employment>>(this.Employments),
                EducationsTitle = this.EducationsTitle,
                Educations = JsonConvert.DeserializeObject<List<Education>>(this.Educations),
                SkillsTitle = this.SkillsTitle,
                Skills = JsonConvert.DeserializeObject<List<Skill>>(this.Skills),
                VolunteeringActivitiesTitle = this.VolunteeringActivitiesTitle,
                VolunteeringActivities = JsonConvert.DeserializeObject<List<Employment>>(this.VolunteeringActivities),
                CertificatesTitle = this.CertificatesTitle,
                Certificates = JsonConvert.DeserializeObject<List<Certificate>>(this.Certificates),
                PublicationsTitle = this.PublicationsTitle,
                Publications = JsonConvert.DeserializeObject<List<Publication>>(this.Publications),
                HobbiesTitle = this.HobbiesTitle,
                Hobbies = JsonConvert.DeserializeObject<List<string>>(this.Hobbies),
            };
        }
        private string languageCode;
        public string LanguageCode
        {
            get => languageCode;
            set
            {
                languageCode = value;
                PartitionKey = value;
            }
        }
        public string AvatarLink { get; set; }

        public string BasicInfoTitle { get; set; }

        public string BasicInfo { get; set; }

        public string EmploymentsTitle { get; set; }

        public string Employments { get; set; }

        public string EducationsTitle { get; set; }

        public string Educations { get; set; }

        public string SkillsTitle { get; set; }

        public string Skills { get; set; }

        public string VolunteeringActivitiesTitle { get; set; }

        public string VolunteeringActivities { get; set; }

        public string CertificatesTitle { get; set; }

        public string Certificates { get; set; }

        public string PublicationsTitle { get; set; }

        public string Publications { get; set; }

        public string HobbiesTitle { get; set; }

        public string Hobbies { get; set; }

    }
}
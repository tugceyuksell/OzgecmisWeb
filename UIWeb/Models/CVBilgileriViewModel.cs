using Entities;

namespace UIWeb.Models
{
    public class CVBilgileriViewModel
    {
        public PersonalInformation PersonalInformation { get; set; }
        public IList<Abilities> Abilities { get; set; }
        public AboutMe AboutMe { get; set; }
        public IList<Projects> Projects { get; set; }
        public IList<Experience> Experience { get; set; }
        public IList<CoursesAndCertificates> CoursesAndCertificates { get; set; }

    }
}

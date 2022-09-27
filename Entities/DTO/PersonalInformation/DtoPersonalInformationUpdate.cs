using Core.Abstract;
namespace Entities.DTO.PersonalInformation
{
    public class DtoPersonalInformationUpdate:IDTO
    {
        public Guid UID { get; set; }
        public string NameSurname { get; set; }
        public string Licence { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public string Medium { get; set; }
        public string Gender { get; set; }
        public string DrivingLicense { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}

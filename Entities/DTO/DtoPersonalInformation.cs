using Core.Abstract;

namespace Entities.DTO
{
    public class DtoPersonalInformation:IDTO
    {
        public Guid UID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
    }
}

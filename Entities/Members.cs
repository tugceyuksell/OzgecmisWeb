using Core.Abstract;
namespace Entities
{
    public class Members: IEntity
    {
        public Guid UID { get; set; }
        public string NameSurname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}

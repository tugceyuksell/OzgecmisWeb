using DataAccess.Repository;
namespace DataAccess.Abstract
{
    public interface IMembersRepo : IRepositories<Members>
    {
        public Task<Members> Login(string Email, string Passwords);
        public Task<string> ForgotPasswords(string Email);
    }
}

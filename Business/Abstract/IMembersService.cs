namespace Business.Abstract
{
    public interface IMembersService
    {
        public Task<IResult> AddAsync(Members data);
        public Task<IResult> UpdateAsync(Members data);
        public Task<IResult> DeleteAsync(Guid UID);
        public Task<Members> GetSingleMembersAsync(Guid UID);
        public Task<IList<Members>> GetAllMembersAsync();
        public Task<Members> LoginAsync(string Email, string Password);
        public Task<string> PaswordForgotAsync(string Email);
    }
}

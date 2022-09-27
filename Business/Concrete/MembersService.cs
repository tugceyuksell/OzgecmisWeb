using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MembersService : IMembersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MembersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> AddAsync(Members data)
        {
            return await _unitOfWork.RepoMembers.AsyncAdd(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(Guid UID)
        {
            return await _unitOfWork.RepoMembers.AsyncDelete(x => x.UID == UID).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<Members>> GetAllMembersAsync()
        {
            return await _unitOfWork.RepoMembers.AsyncGetAll();
        }

        public async Task<Members> GetSingleMembersAsync(Guid UID)
        {
            return await _unitOfWork.RepoMembers.AsyncGetSingle(x => x.UID == UID);
        }

        public async Task<Members> LoginAsync(string Email, string Password)
        {
            return await _unitOfWork.RepoMembers.Login(Email, Password);
        }

        public async Task<string> PaswordForgotAsync(string Email)
        {
            return await _unitOfWork.RepoMembers.ForgotPasswords(Email);
        }

        public async Task<IResult> UpdateAsync(Members data)
        {
            return await _unitOfWork.RepoMembers.AsyncUpdate(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
    }
}

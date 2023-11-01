

using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface ICommentDR
    {
        public Task<IEnumerable<RequestComments>> GetAllCommentsByRequestId(string requestId);

        public Task<RequestComments> GetCommentById(Guid id);

        public Task<CreateResponse> CreateComment(RequestComments comment);

        public Task<UpdateResponse> UpdateComment(RequestComments comment);

    }
}

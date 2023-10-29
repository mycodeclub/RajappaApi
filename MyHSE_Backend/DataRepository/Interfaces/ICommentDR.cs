

using MyHSE_Backend.Data.DbModels.LK01;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.ViewModels;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface ICommentDR
    {
        public Task<IEnumerable<Comment>> GetAllCommentsByRequestId(string requestId);

        public Task<Comment> GetCommentById(Guid id);

        public Task<CreateResponse> CreateComment(Comment comment);

        public Task<UpdateResponse> UpdateComment(Comment comment);

    }
}

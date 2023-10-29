using Microsoft.EntityFrameworkCore;
using MyHSE_Backend.Data.DbModels.Settings;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class CommentDR : ICommentDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public CommentDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        }

        public async Task<CreateResponse> CreateComment(Comment comment)
        {
            var response = new CreateResponse();


            comment.CreatedOn = DateTime.Now;

            _context.Comments.Add(comment);
            try { await _context.SaveChangesAsync(); }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (response.ErrorMessages == null)
                    response.ErrorMessages = new List<string>();
                response.ErrorMessages.Add(ex.Message);
                response.ErrorMessages.Add(ex.InnerException?.Message);
                response.ErrorMessages.Add(ex.StackTrace);
                return response;
            }
            response.UniqueId = comment.CommentId;
            response.IsCreated = true;
            return response;
        }


        public async Task<IEnumerable<Comment>> GetAllCommentsByRequestId(string requestId)
        {
            IEnumerable<Comment> Comments;
            Comments = await _context.Comments.Where(i => i.RequestId.Equals(requestId)).ToListAsync();
            return Comments;
        }

        public async Task<Comment> GetCommentById(Guid id)
        {
            try
            {
                return await _context.Comments.Where(u => u.CommentId.Equals(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UpdateResponse> UpdateComment(Comment comment)
        {
            var response = new UpdateResponse();

            var SelectedInc = await GetCommentById(comment.CommentId);

            if (SelectedInc == null)
            {
                response.ErrorMessages = new List<string>() { "Comment does not exist with given Id" };
                return response;
            }
            try
            {
                _context.Entry(SelectedInc).CurrentValues.SetValues(comment);
                _context.SaveChanges();
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
                if (response.ErrorMessages == null)
                    response.ErrorMessages = new List<string>();
                response.ErrorMessages.Add(ex.Message);
                response.ErrorMessages.Add(ex.InnerException.Message);
                response.ErrorMessages.Add(ex.StackTrace);
                return response;
            }
            response.UniqueId = comment.CommentId;
            response.IsUpdated = true;
            return response;

        }
    }
}

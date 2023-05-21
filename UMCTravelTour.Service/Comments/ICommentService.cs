using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Comments;
using UMCTravelTour.ViewModel.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Comments
{
    public interface ICommentService
    {
        Task<ResponseResult<CommentVm>> AddAsync(CommentVm commentVm);
        Task<ResponseResult<CommentVm>> DeleteAsync(int id);
        Task<IEnumerable<CommentVm>> GetAllAsync();
        Task<CommentVm> GetByIdAsync(int id);
        Task<ResponseResult<CommentVm>> UpdateAsync(CommentVm commentVm);
        public PagedVm<CommentVm> GetPaging(FilterPaging filterPaging);
        public IEnumerable<CommentVm> GetAll();
        public CommentVm GetById(int id);
    }
}
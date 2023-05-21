using AutoMapper;
using UMCTravelTour.Common.Constants;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.Comments;
using UMCTravelTour.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseResult<CommentVm>> AddAsync(CommentVm commentVm)
        {
            try
            {
                var comment = _mapper.Map<Comment>(commentVm);
                _unitOfWork.CommentRepository.Add(comment);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<CommentVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentVm>(ex.Message);
            }
        }

        public async Task<ResponseResult<CommentVm>> DeleteAsync(int id)
        {
            try
            {
                _unitOfWork.CommentRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<CommentVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentVm>(ex.Message);
            }
        }

        public IEnumerable<CommentVm> GetAll()
        {
            var comments = _unitOfWork.CommentRepository.GetAll();
            var commentVms = _mapper.Map<IEnumerable<CommentVm>>(comments);
            return commentVms;
        }

        public async Task<IEnumerable<CommentVm>> GetAllAsync()
        {
            var comments = await _unitOfWork.CommentRepository.GetAllAsync();
            var commentVms = _mapper.Map<IEnumerable<CommentVm>>(comments);
            return commentVms;
        }

        public CommentVm GetById(int id)
        {
            var comment = _unitOfWork.CommentRepository.GetById(id);
            var commentVm = _mapper.Map<CommentVm>(comment);
            return commentVm;
        }

        public async Task<CommentVm> GetByIdAsync(int id)
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            var commentVm = _mapper.Map<CommentVm>(comment);
            return commentVm;
        }

        public PagedVm<CommentVm> GetPaging(FilterPaging filterPaging)
        {
            Func<IEnumerable<Comment>, IOrderedEnumerable<Comment>> predicate = null;
            if (filterPaging.TypeOfSort == Constant.Sort.ASC)
            {
                if (filterPaging.SortBy == Constant.SortBy.Rate)
                {
                    predicate = x => x.OrderBy(x => x.RatePoint);
                }
                else
                {
                    predicate = x => x.OrderBy(x => x.LastModifiedOn);
                }
            }
            else
            {
                if (filterPaging.SortBy == Constant.SortBy.Rate)
                {
                    predicate = x => x.OrderByDescending(x => x.RatePoint);
                }
                else
                {
                    predicate = x => x.OrderByDescending(x => x.LastModifiedOn);
                }
            }
            Func<Comment, bool> filter = null;
            if (!string.IsNullOrEmpty(filterPaging.Keyword))
            {
                filter = x => x.Content.ToLower().Contains(filterPaging.Keyword.ToLower());
            }
            PagedVm<Comment> comments = _unitOfWork.CommentRepository.GetPaging(null, filter, predicate, filterPaging.PageSize, filterPaging.PageIndex);
            IEnumerable<CommentVm> commentVms = this._mapper.Map<IEnumerable<CommentVm>>(comments.Data.AsEnumerable());
            return new PagedVm<CommentVm>(commentVms, filterPaging.PageIndex, filterPaging.PageSize, comments.TotalPage);
        }

        public async Task<ResponseResult<CommentVm>> UpdateAsync(CommentVm commentVm)
        {
            try
            {
                var comment = _mapper.Map<Comment>(commentVm);
                _unitOfWork.CommentRepository.Update(comment);
                await _unitOfWork.SaveChangesAsync();
                return new ResponseResult<CommentVm>();
            }
            catch (Exception ex)
            {
                return new ResponseResult<CommentVm>(ex.Message);
            }
        }
    }
}

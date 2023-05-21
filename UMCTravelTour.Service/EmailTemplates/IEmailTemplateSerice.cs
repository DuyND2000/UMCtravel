using UMCTravelTour.Service.BaseEntities;
using UMCTravelTour.ViewModel.EmailTemplates;
using UMCTravelTour.ViewModel.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.EmailTemplates
{
    public interface IEmailTemplateSerice
    {
        IEnumerable<EmailTemplateVm> GetAll();
        Task<IEnumerable<EmailTemplateVm>> GetAllAsync();
        Task<ResponseResult<EmailTemplateVm>> AddAsync(EmailTemplateVm templateVm);
        Task<ResponseResult<EmailTemplateVm>> UpdateAsync(EmailTemplateVm templateVm);
        Task<ResponseResult<EmailTemplateVm>> DeleteAsync(int id);
        Task<EmailTemplateVm> GetByIdAsync(int id);
        public PagedVm<EmailTemplateVm> GetPaging(FilterPaging filterPaging);

        Task<string> SendGmail(EmailTemplateVm templateVm);

        EmailTemplateVm GetByTilte(string title);
    }
}

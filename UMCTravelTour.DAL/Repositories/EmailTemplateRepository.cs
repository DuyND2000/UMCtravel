using UMCTravelTour.Core;
using UMCTravelTour.Core.Models;
using UMCTravelTour.DAL.Infrastructures;
using UMCTravelTour.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.DAL.Repositories
{
    public class EmailTemplateRepository : GenericRepository<EmailTemplate>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(UMCTravelContext context) : base(context)
        {
        }

        public EmailTemplate GetByTitle(string title)
        {
            return Context.EmailTemplates.FirstOrDefault(x => x.EmailTilte == title);
        }
    }
}

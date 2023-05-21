using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.ViewModel.EmailTemplates
{
    public class EmailTemplateVm
    {

        [Key]
        public int EmailId { get; set; }
        [Required]
        [Display(Name = "Tiêu đề email")]

        public string EmailTilte { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        [Required]
        [MaxLength(500)]
        public string Object { get; set; }

        [Display(Name = "Nội dung")]
        public string Body { get; set; }
    }
}

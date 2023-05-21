using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Core.Models
{
    public class EmailTemplate
    {
        [Key]
        public int EmailId { get; set; }
        [Required(ErrorMessage = "Tiêu đề Email không được để trống")]
        [Display(Name="Tiêu đề Email")]    
    
        public string EmailTilte { get; set; }     
        public string To { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        [Required(ErrorMessage = "Không được để trống")]
        [MaxLength(500)]
        public string Object { get; set; }
        public string Body { get; set; }
    }
}

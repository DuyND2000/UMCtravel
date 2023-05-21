using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Core.Models
{
    public class BaseEntity
    {
        [Display(Name = "Người sửa")]
        public string LastModifiedBy { get; set; }

        [Display(Name = "Ngày sửa")]
        public DateTime LastModifiedOn { get; set; } = DateTime.Now;
    }
}

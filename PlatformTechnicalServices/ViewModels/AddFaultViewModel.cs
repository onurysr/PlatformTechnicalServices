using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.ViewModels
{
    
    public class AddFaultViewModel
    {
        [Required(ErrorMessage ="Telefon Numarası Girilmek Zorunda")]
        [StringLength(11,MinimumLength =10,ErrorMessage ="Telefon numarası en az 10 haneli olmalıdır.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Adres Alanı Girilmek Zorunda")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Açıklama Alanı Girilmek Zorunda")]
        public string Description { get; set; }
        public string Subject { get; set; }
    }
}

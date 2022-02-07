using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Girilmesi Zorunlu.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Girilmesi Zorunlu.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre En az 6 karakter olmalı")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

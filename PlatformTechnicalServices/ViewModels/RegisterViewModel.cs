using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name="Adı")]
        [Required(ErrorMessage ="Ad Alanı Girilmesi Zorunlu.")]
        [StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        [Required(ErrorMessage = "Soyad Alanı Girilmesi Zorunlu.")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Display(Name="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adı Alanı Girilmesi Zorunlu.")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Email Alanı Zorunlu")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Şifre Alanı Girilmesi Zorunlu.")]
        [StringLength(100,MinimumLength =6,ErrorMessage ="Şifre En az 6 karakter olmalı")]
        [DataType(DataType.Password)]
        [Display(Name ="Şifre")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Alanı Girilmesi Zorunlu.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Onay")]
        [Compare(nameof(Password),ErrorMessage ="Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}

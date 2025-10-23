using System.ComponentModel.DataAnnotations;

namespace PortfolioTask1.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; } // Identity 'UserName' kullanır

        [Required(ErrorMessage = "Parola zorunludur.")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}

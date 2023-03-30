using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AkilliTicaretCase.Models
{
    public class LoginModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        
    }
    public class ProductModel
    {
        public string Gorsel { get; set; }
        [Required]
        public string Stokkodu { get; set; }
        public string Stokadi { get; set; }
        public string Marka { get; set; }
        public string Stok { get; set; }
        public double Listefiyati { get; set; }
        public string Doviz { get; set; }
        public double Nakitiskontosu { get; set; }
        public double Tekcekimiskontosu { get; set; }
        public double Altitaksitiskontosu { get; set; }
        public double Acikhesapiskontosu { get; set; }


    }
}
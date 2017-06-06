using System.ComponentModel.DataAnnotations;

namespace BusinessLayerAccess.Models
{
    public class UserRegisterModel
    {
        [Required]
        [Display(Name = "Введите имя пользователя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Введите логин")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль должен содержать не менее {2} символов", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
            ErrorMessage = "Введите корректный email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Введите номер телефона")]
        public string Phone { get; set; }
    }
}

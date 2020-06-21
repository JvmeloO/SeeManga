using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeManga.Models
{
    public class RegisterUserModel
    {
        [Key]
        [Required(ErrorMessage = "O campo deve ser preechido!")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo deve ser preechido!")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Formato do E-mail inválido!")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo deve ser preechido!")]
        [MinLength(5, ErrorMessage = "A senha deve conter pelo menos 5 caracteres!")]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repita sua senha!")]
        [MinLength(5, ErrorMessage = "A senha deve conter pelo menos 5 caracteres!")]
        [MaxLength(30)]
        public string ConfirmPassword { get; set; }
    }

    public class LoginUserModel
    {
        [Required(ErrorMessage = "O campo deve ser preechido!")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Formato do E-mail inválido!")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo deve ser preechido!")]
        [MinLength(5, ErrorMessage = "A senha deve conter pelo menos 5 caracteres!")]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}

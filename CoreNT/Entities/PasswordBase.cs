using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreNT.Entities
{
    public class PasswordBase
    {
        [Required(ErrorMessage = "Şifre girmediniz")]
        [StringLength(255, ErrorMessage = "En az 6 karakter olmalı", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "2 şifre de aynı olmalı")]
        [StringLength(255, ErrorMessage = "En az 6 karakter olmalı", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

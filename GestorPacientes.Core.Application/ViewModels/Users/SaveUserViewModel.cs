using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPacientes.Core.Application.ViewModels.Users
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a name!!")]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a last name!!")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a email!!")]
        [DataType(DataType.Text)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a user name!!")]
        [DataType(DataType.Text)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a password!!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "The password must be the same")]
        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "You must select a rol")]
        [Range(1, int.MaxValue, ErrorMessage = "You must enter a rol")]
        public int IdRol {  get; set; }
    }
}

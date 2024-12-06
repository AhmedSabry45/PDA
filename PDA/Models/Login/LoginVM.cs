using System.ComponentModel.DataAnnotations;

namespace PDA.Models;

public class LoginVM
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}


public class ForgotPasswordVM
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string Message { get; set; }
    public string MessageColor { get; set; }

    public IFormFile? DamageDocument { get; set; }

}


public class ChangePasswordVM
{
    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("ConfirmPassword", ErrorMessage = "Passwords do not match.")]
    public string NewPassword { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}

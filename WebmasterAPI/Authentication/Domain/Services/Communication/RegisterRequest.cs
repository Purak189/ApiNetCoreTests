using System.ComponentModel.DataAnnotations;

namespace WebmasterAPI.Authentication.Domain.Services.Communication;

public class RegisterRequest
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
    [Required] public string Names { get; set; }
    [Required] public string Lastnames { get; set; }
    [Required] public char User_Type { get; set; }
    
    public string cellphone { get; set; } = "999 999 999";
    public string profile_img_url { get; set; } = "https://cdn-icons-png.flaticon.com/512/3237/3237472.png";
}
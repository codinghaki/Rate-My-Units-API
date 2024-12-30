using System.ComponentModel.DataAnnotations;

namespace Rate_My_Units_API.Dtos.Account;

public record LoginDto(
    [Required]
    string Username,
    [Required]
    string Password);
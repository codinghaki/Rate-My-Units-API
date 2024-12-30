using System.ComponentModel.DataAnnotations;

namespace Rate_My_Units_API.Dtos.Account;

public record RegisterDto(
    [Required]
    string? Username,
    [Required]
    [EmailAddress]
    string? Email,
    [Required]
    string? Password);
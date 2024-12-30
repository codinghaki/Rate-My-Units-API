namespace Rate_My_Units_API.Dtos.Account;

public record NewUserDto(
    string Username,
    string Email,
    string Token);
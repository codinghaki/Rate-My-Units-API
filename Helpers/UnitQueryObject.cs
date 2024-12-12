namespace Rate_My_Units_API.Helpers;

public record UnitQueryObject(
    string? Code,
    int PageNumber = 1,
    int PageSize = 10
    );
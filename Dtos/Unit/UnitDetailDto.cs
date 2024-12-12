namespace Rate_My_Units_API.Dtos.Unit;

public record UnitDetailDto(
    string Code,
    string Name,
    List<ReviewDto> Reviews);
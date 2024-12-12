using Rate_My_Units_API.Dtos.Unit;
using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Mappers;

public static class UnitMapper
{
    public static UnitDetailDto ToDetailDto(this Unit unit)
    {
        return new UnitDetailDto(
            unit.Code,
            unit.Name,
            unit.Reviews.Select(review => review.ToDto()).ToList());
    }

    public static UnitListDto ToListDto(this Unit unit)
    {
        return new UnitListDto(
            unit.Code,
            unit.Name
        );
    }
}
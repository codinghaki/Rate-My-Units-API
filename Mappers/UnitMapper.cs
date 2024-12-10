using Rate_My_Units_API.Dtos.Unit;
using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Mappers;

public static class UnitMapper
{
    public static UnitDto ToDto(this Unit unit)
    {
        return new UnitDto(unit.Code, unit.Name);
    }
}
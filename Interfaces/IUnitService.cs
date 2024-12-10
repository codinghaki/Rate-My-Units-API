using Rate_My_Units_API.Dtos.Unit;
using Rate_My_Units_API.Models;

namespace Rate_My_Units_API.Interfaces;

public interface IUnitService
{
    Task<List<UnitDto>> GetAllUnitsAsync();
    
    Task<UnitDto?> GetUnitByIdAsync(int id);
}
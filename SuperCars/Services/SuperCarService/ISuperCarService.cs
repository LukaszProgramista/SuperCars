using SuperCarAPI.Models;

namespace SuperCarAPI.Services.SuperCarService
{
    public interface ISuperCarService
    {
        Task<List<SuperCar>> GetAllCars();
        Task<SuperCar>? GetOneCar(int id);
        Task<List<SuperCar>> AddCar(SuperCar car);
        Task<List<SuperCar>>? UpdateCar(int id, SuperCar request);
        Task<List<SuperCar>>? DeleteCar(int id);
    }
}

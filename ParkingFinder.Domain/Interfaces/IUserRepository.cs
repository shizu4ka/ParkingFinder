using ParkingFinder.Domain.DTOs;
using ParkingFinder.Domain.Entities;

namespace ParkingFinder.Domain.Interfaces;

public interface IUserRepository
{
    Task<IReadOnlyList<User>> GetAllUsersAsync();
    Task<IReadOnlyList<User>> GetUsersByFiltersAsync(UsersFilters usersFilters);
    Task AddNewUser(User User);
    Task<bool> UpdateUser(Guid Id, User User);
    Task<bool> DeleteUser(Guid Id);
}
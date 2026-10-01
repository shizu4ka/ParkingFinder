using Microsoft.EntityFrameworkCore;
using ParkingFinder.Domain.DTOs;
using ParkingFinder.Domain.Entities;
using ParkingFinder.Domain.Interfaces;

namespace ParkingFinder.Infrastructure.Data;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<User>> GetAllUsersAsync()
    {
        return await _db.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<User>> GetUsersByFiltersAsync(UsersFilters usersFilters)
    {
        IQueryable<User> query = _db.Users;

        if (usersFilters.Id.HasValue)
        {
            query = query.Where(u => u.Id == usersFilters.Id);
        }

        if (usersFilters.Name != null)
        {
            query = query.Where(u => u.Name == usersFilters.Name);
        }

        if (usersFilters.Surname != null)
        {
            query = query.Where(u => u.Surname == usersFilters.Surname);
        }

        if (usersFilters.PhoneNumber != null)
        {
            query = query.Where(u => u.PhoneNumber == usersFilters.PhoneNumber);
        }

        if (usersFilters.CarId != null)
        {
            query = query.Where(u => u.CarId == usersFilters.CarId);
        }
        return await query.ToListAsync();
    }

    public async Task AddNewUser(User user)
    {
        var newUser = new User
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            PhoneNumber = user.PhoneNumber,
            CarId = user.CarId
        };
        await _db.Users.AddAsync(newUser);
        await _db.SaveChangesAsync();
    }

    public async Task<bool> UpdateUser(Guid id, User user)
    {
        var newUser = _db.Users.Find(id);
        if (newUser == null) return false;

        newUser.Id = user.Id;
        newUser.Name = user.Name;
        newUser.Surname = user.Surname;
        newUser.PhoneNumber = user.PhoneNumber;
        newUser.CarId = user.CarId;

        _db.Users.Update(newUser);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        await _db.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();
        return true;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository.Person;
using Domain.Interfaces;
using Domain.Interfaces.Person;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly StudentsContext _context;
    private IRol _roles;
    private IUser _users;

    public UnitOfWork(StudentsContext context)
    {
        _context = context;
    }

    public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepo(_context);
            }
            return _roles;
        }
    }
    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepo(_context);
            }
            return _users;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
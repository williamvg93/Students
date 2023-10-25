using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Person;
using Domain.Interfaces.Person;
using Persistence.Data;

namespace Application.Repository.Person;

public class RolRepo : GenericRepository<Rol>, IRol
{
    private readonly StudentsContext _context;

    public RolRepo(StudentsContext context) : base(context)
    {
        _context = context;
    }
}
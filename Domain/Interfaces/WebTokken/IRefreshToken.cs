using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.WebTokken;

namespace Domain.Interfaces.WebTokken;

public interface IRefreshToken : IGenericRepository<RefreshToken>
{

}
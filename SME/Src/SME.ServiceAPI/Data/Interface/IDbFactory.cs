using SME.ServiceAPI.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SME.ServiceAPI.Data.Interface
{
    public interface IDbFactory
    {
        ApplicationDbContext GetDataContext { get; }
    }
}

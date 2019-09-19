using SME.ServiceAPI.Business.Manager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Manager.Product
{
   public interface IProductManager:IActionManager
    {
        Task GetProduct(string Id);
    }
}

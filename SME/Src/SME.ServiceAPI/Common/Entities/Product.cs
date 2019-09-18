using SME.ServiceAPI.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Common.Entities
{
    public class Product:BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}

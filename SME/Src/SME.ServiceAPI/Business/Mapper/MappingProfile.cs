using AutoMapper;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SME.ServiceAPI.Business.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<Customer, CustomerModel>().ReverseMap();
        }


    }
}

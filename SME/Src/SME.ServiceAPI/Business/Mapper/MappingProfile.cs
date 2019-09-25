using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<ServiceCall, ServiceCallModel>();
            CreateMap<ServiceCallProduct, ServiceCallProductModel>();
            CreateMap<ServiceCallHistory, ServiceCallHistoryModel>();
            CreateMap<ServiceCallFeedback, ServiceCallFeedbackModel>();
            CreateMap<IdentityUserClaim<string>, UserClaimModel>();
            CreateMap<IdentityRoleClaim<string>, RoleClaimModel>();
            CreateMap<IdentityUserRole<string>, UserRoleModel>();
        }


    }
}

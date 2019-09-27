using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SME.ServiceAPI.Business.Contracts.BusinessEntities;
using SME.ServiceAPI.Common.Entities;
using SME.ServiceAPI.Common.Idenitity;
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
            CreateMap<IdentityUserRole<string>, UserRoleAssignModel>();

            CreateMap<AppUser, UserModel>()
              .ForMember(d => d.Phone, s => s.MapFrom(x => x.PhoneNumber)).ReverseMap();

            CreateMap<AppUser, UserModel>()
                .ForMember(d=>d.Phone,s=>s.MapFrom(x=>x.PhoneNumber)).ReverseMap();

            CreateMap<AppUser, UserNewModel>()
                .ForMember(d => d.Phone, s => s.MapFrom(x => x.PhoneNumber)).ReverseMap();

            CreateMap<AppUser, UserEditModel>()
                .ForMember(d => d.Phone, s => s.MapFrom(x => x.PhoneNumber)).ReverseMap();

            CreateMap<AppRole, RoleModel>().ReverseMap();

            CreateMap<ClaimMaster, ClaimNewModel>().ReverseMap();
            CreateMap<ClaimMaster, ClaimModel>().ReverseMap();
        }


    }
}



using AutoMapper;
using GreenTunnel.Core;
using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.ViewModels.Response.Category;
using GreenTunnel.Infrastructure.ViewModels.Response.Description;
using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using GreenTunnel.Infrastructure.ViewModels.Response.InputType;
using GreenTunnel.Infrastructure.ViewModels.Response.TestType;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlaces;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkSpaces;
using Microsoft.AspNetCore.Identity;

namespace GreenTunnel.Infrastructure.ViewModels;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ApplicationUser, UserViewModel>()
            .ForMember(d => d.Roles, map => map.Ignore());
        CreateMap<UserViewModel, ApplicationUser>()
            .ForMember(d => d.Roles, map => map.Ignore())
            .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

        CreateMap<ApplicationUser, UserEditViewModel>()
            .ForMember(d => d.Roles, map => map.Ignore());
        CreateMap<UserEditViewModel, ApplicationUser>()
            .ForMember(d => d.Roles, map => map.Ignore())
            .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

        CreateMap<ApplicationUser, UserPatchViewModel>()
            .ReverseMap();

        CreateMap<ApplicationRole, RoleViewModel>()
            .ForMember(d => d.Permissions, map => map.MapFrom(s => s.Claims))
            .ForMember(d => d.UsersCount, map => map.MapFrom(s => s.Users != null ? s.Users.Count : 0))
            .ReverseMap();
        CreateMap<RoleViewModel, ApplicationRole>()
            .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

        CreateMap<IdentityRoleClaim<string>, ClaimViewModel>()
            .ForMember(d => d.Type, map => map.MapFrom(s => s.ClaimType))
            .ForMember(d => d.Value, map => map.MapFrom(s => s.ClaimValue))
            .ReverseMap();

        CreateMap<ApplicationPermission, PermissionViewModel>()
            .ReverseMap();

        CreateMap<IdentityRoleClaim<string>, PermissionViewModel>()
            .ConvertUsing(s => (PermissionViewModel)ApplicationPermissions.GetPermissionByValue(s.ClaimValue));

           
           CreateMap<GreenTunnel.Core.Entities.Factory, GetFacoriesListResponseModel>();
           CreateMap<GreenTunnel.Core.Entities.InputType, GetInputTypesListResponseModel>();
           CreateMap<GreenTunnel.Core.Entities.Category, GetCategoriesListResponseModel>();
           CreateMap<GreenTunnel.Core.Entities.Description, GetDescriptionsListResponseModel>();

        CreateMap<GreenTunnel.Core.Entities.Factory, FactoryViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Workplaces, opt => opt.MapFrom(src => src.Workplaces))
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());

        CreateMap<Workplace, GetWorkplacesListResponseModel>();
        CreateMap<Workspace, GetWorkspacesListResponseModel>();

        CreateMap<Workplace, WorkplaceViewModel>()
            .ForMember(dest => dest.FactoryName, opt => opt.MapFrom(src => src.Factory.Name))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());

        CreateMap<Workspace, WorkSpaceViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.WorkplaceName, opt => opt.MapFrom(src => src.Workplace.Name))
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore());

        CreateMap<Workspace, WorkSpaceViewModel>();
        CreateMap<Moulds, MouldsViewModel>()
            .ReverseMap();

        CreateMap<TestType, TestTypeViewModel>();
        CreateMap<TestType, GetTestTypesListResponseModel>();
        CreateMap<Test, TestViewModel>()
         .ForMember(dest => dest.TestTypeName, opt => opt.MapFrom(src => src.TestType.Name));
        //   CreateMap<Test, GetTestListResponseModel>();
    }
}
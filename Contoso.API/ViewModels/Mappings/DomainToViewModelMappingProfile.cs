using AutoMapper;
using Contoso.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Sale, SaleViewModel>();
            CreateMap<Seller, SellerViewModel>();
            CreateMap<Users, UsersViewModel>();
            CreateMap<Operation, OperationViewModel>();

        }
    }
}

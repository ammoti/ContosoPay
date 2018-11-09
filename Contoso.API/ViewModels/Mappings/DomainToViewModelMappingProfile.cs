using AutoMapper;
using Contoso.Model.Entities;
using Contoso.Model.Enumration;
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
            CreateMap<Operation, OperationViewModel>().ForMember(vm => vm.SellerName,
                map => map.MapFrom(s => s.Seller.Name)).ForMember(vm => vm.OperationType, map =>
                map.MapFrom(s => ((OperationType)s.OperationType).ToString()));
            CreateMap<Report, ReportViewModel>().ForMember(vm => vm.SellerName,
             map => map.MapFrom(s => s.Seller.Name));

        }
    }
}

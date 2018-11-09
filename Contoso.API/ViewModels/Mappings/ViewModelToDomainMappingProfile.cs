using AutoMapper;
using Contoso.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<SaleViewModel,Sale>();
            CreateMap<SellerViewModel, Seller>();
            CreateMap<UsersViewModel,Users>();
            CreateMap<OperationViewModel, Operation>();
            CreateMap<ReportViewModel, Report>();
        }
    }
}

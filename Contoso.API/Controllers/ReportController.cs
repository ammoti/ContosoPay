using AutoMapper;
using Contoso.API.ViewModels;
using Contoso.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Contoso.Data.Abstract.IRepositories;

namespace Contoso.API.Controllers
{
    [Route("api/[controller]")]
    public class ReportController:Controller
    {
        private IReportRepository _reportRepository;
        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository= reportRepository;

        }
        [HttpGet(Name = "GetReport")]
        public IActionResult GetAll()
        {
            IEnumerable<Report> _reports= _reportRepository.AllIncluding(x => x.Seller).ToList();

            if (_reports != null)
            {
                List<ReportViewModel> _opsVM = Mapper.Map<IEnumerable<Report>, IEnumerable<ReportViewModel>>(_reports).GroupBy(x=>x.SellerId).Select(rp=>new ReportViewModel {
                    SellerName=rp.First().SellerName,
                    Id=rp.First().Id,
                    Discount=rp.Sum(x=>x.Discount)
                }).ToList();
                return new OkObjectResult(_opsVM);
            }
            else
            {
                return NotFound();
            }
        }

    }
}

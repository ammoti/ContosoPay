using AutoMapper;
using Contoso.API.ViewModels;
using Contoso.Model.Entities;
using Contoso.Model.Enumration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Contoso.Data.Abstract.IRepositories;

namespace Contoso.API.Controllers
{
    [Route("api/[controller]")]
    public class SaleController : Controller
    {
        private ISaleRepository _saleRepository;
        private ISellerRepository _sellerRepository;
        private IOperationRepository _operationRepository;
        private IReportRepository _reportRepository;

        public SaleController(ISaleRepository saleRepository, ISellerRepository sellerRepository, IOperationRepository operationRepository, IReportRepository reportRepository)
        {
            _saleRepository = saleRepository;
            _sellerRepository = sellerRepository;
            _operationRepository = operationRepository;
            _reportRepository = reportRepository;
        }

        [HttpGet("{id}", Name = "GetSale")]
        public IActionResult Get(int id)
        {
            Sale _sale = _saleRepository
                .GetSingle(s => s.Id == id);

            if (_sale != null)
            {
                SaleViewModel _saleVM = Mapper.Map<Sale, SaleViewModel>(_sale);
                return new OkObjectResult(_saleVM);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody]SaleViewModel sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sale _newSale = Mapper.Map<SaleViewModel, Sale>(sale);
            _newSale.CreateDate = DateTime.Now;

            _saleRepository.Add(_newSale);
            _saleRepository.Commit();

            IEnumerable<Operation> operations = _operationRepository.FindBy(x => x.SellerId == sale.SellerId).ToList();

            var cardInit = operations.FirstOrDefault(x => x.OperationType == OperationType.CardInitiate);
            var cardSale = operations.FirstOrDefault(x => x.OperationType == OperationType.Sale);

            Report newReport = new Report()
            {
                Discount = sale.SaleType == SaleType.CardInitiate ? (cardInit != null ? cardInit.Discount : 5) : (sale.Price * (cardSale != null ? cardSale.Discount : 10) / 100),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                OperationType = sale.SaleType == SaleType.CardInitiate ? OperationType.CardInitiate.ToString() : OperationType.Sale.ToString(),
                SellerId = sale.SellerId
            };
            _reportRepository.Add(newReport);
            _reportRepository.Commit();

            sale = Mapper.Map<Sale, SaleViewModel>(_newSale);

            CreatedAtRouteResult result = CreatedAtRoute("GetSale", new { controller = "Sale", id = sale.Id }, sale);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SaleViewModel sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sale _saleDb = _saleRepository.GetSingle(id);

            if (_saleDb == null)
            {
                return NotFound();
            }
            else
            {
                _saleDb.SellerId = sale.SellerId;
                _saleDb.Price = sale.Price;
                _saleDb.CardNo = sale.CardNo;

                _saleRepository.Commit();
            }

            sale = Mapper.Map<Sale, SaleViewModel>(_saleDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}", Name = "RemoveSale")]
        public IActionResult Delete(int id)
        {
            Sale _saleDb = _saleRepository.GetSingle(id);

            if (_saleDb == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _saleRepository.Delete(_saleDb);

                _saleRepository.Commit();

                return new NoContentResult();
            }
        }

        [HttpPost("CardInit", Name = "CardInitiate")]
        public IActionResult CardInitiate([FromBody] CardViewModel cardViewModel)
        {
            long cardNo = Core.Extensions.CardNoDecrypt(cardViewModel.SellerCode);
            var seller = _sellerRepository.FindBy(x => x.MinRange <= cardNo && x.MaxRange >= cardNo).FirstOrDefault();
            if (seller != null)
            {
                Sale sale = new Sale()
                {
                    CardNo = cardViewModel.CardNo,
                    IsActive = true,
                    IsDeleted = false,
                    Price = 0,
                    SellerId = seller.Id,
                    UpdateDate = DateTime.Now,
                    CreateDate = DateTime.Now
                };
                Operation operation = new Operation()
                {
                    IsActive = true,
                    IsDeleted = false,
                    Discount = 0,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    SellerId = seller.Id,
                    OperationType = Model.Enumration.OperationType.CardInitiate
                };
                _saleRepository.Add(sale);
                _saleRepository.Commit();

                _operationRepository.Add(operation);
                _operationRepository.Commit();

                return new OkObjectResult("Success");
            }
            else
            {
                return new NotFoundObjectResult("Fail");
            }
        }
    }
}
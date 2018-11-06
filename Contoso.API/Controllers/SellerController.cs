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
    public class SellerController : Controller
    {
        private ISellerRepository _sellerRepository;
        public SellerController(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        [HttpGet("{id}", Name = "GetSeller")]
        public IActionResult Get(int id)
        {
            Seller _seller = _sellerRepository
                .GetSingle(s => s.Id == id);

            if (_seller != null)
            {
                SellerViewModel _sellerVM = Mapper.Map<Seller, SellerViewModel>(_seller);
                return new OkObjectResult(_sellerVM);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet(Name = "GetAllSeller")]
        public IActionResult GetAll()
        {
            var _seller = _sellerRepository
                .GetAll();

            if (_seller != null)
            {
                IEnumerable<SellerViewModel> _sellerVM = Mapper.Map<IEnumerable<Seller>,IEnumerable<SellerViewModel>>(_seller);
                return new OkObjectResult(_sellerVM);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create([FromBody]SellerViewModel seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Seller _newSeller = Mapper.Map<SellerViewModel, Seller>(seller);
            _newSeller.CreateDate = DateTime.Now;

            _sellerRepository.Add(_newSeller);
            _sellerRepository.Commit();

            seller = Mapper.Map<Seller, SellerViewModel>(_newSeller);

            CreatedAtRouteResult result = CreatedAtRoute("GetSeller", new { controller = "Seller", id = seller.Id }, seller);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SellerViewModel seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Seller _sellerDb = _sellerRepository.GetSingle(id);

            if (_sellerDb == null)
            {
                return NotFound();
            }
            else
            {
                _sellerDb.Name = seller.Name;
                _sellerDb.MaxRange = seller.MaxRange;
                _sellerDb.MinRange = seller.MinRange;

                _sellerRepository.Commit();
            }

            seller = Mapper.Map<Seller, SellerViewModel>(_sellerDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}", Name = "RemoveSeller")]
        public IActionResult Delete(int id)
        {
            Seller _sellerDb = _sellerRepository.GetSingle(id);

            if (_sellerDb == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _sellerRepository.Delete(_sellerDb);

                _sellerRepository.Commit();

                return new NoContentResult();
            }
        }
    }
}

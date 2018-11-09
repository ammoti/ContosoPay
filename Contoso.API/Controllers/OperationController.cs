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
    public class OperationController : Controller
    {
        private IOperationRepository _operationRepository;
        public OperationController(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        [HttpGet("{id}", Name = "GetOperation")]
        public IActionResult Get(int id)
        {
            Operation _operation = _operationRepository
                .GetSingle(s => s.Id == id);

            if (_operation != null)
            {
                OperationViewModel _operationVM = Mapper.Map<Operation, OperationViewModel>(_operation);
                return new OkObjectResult(_operationVM);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet(Name = "GetAllOperation")]
        public IActionResult GetAll()
        {
            IEnumerable<Operation> _operations = _operationRepository.AllIncluding(x => x.Seller).ToList();

            if (_operations != null)
            {
                IEnumerable<OperationViewModel> _opsVM = Mapper.Map<IEnumerable<Operation>, IEnumerable<OperationViewModel>>(_operations);
                return new OkObjectResult(_opsVM);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody]OperationViewModel operation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Operation _operation = Mapper.Map<OperationViewModel, Operation>(operation);
            _operation.CreateDate = DateTime.Now;

            _operationRepository.Add(_operation);
            _operationRepository.Commit();

            operation = Mapper.Map<Operation, OperationViewModel>(_operation);

            CreatedAtRouteResult result = CreatedAtRoute("GetOperation", new { controller = "Operation", id = operation.Id }, operation);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OperationViewModel operation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Operation _operationDb = _operationRepository.GetSingle(id);

            if (_operationDb == null)
            {
                return NotFound();
            }
            else
            {
                _operationDb.Discount = operation.Discount;
                _operationDb.SellerId = operation.SellerId;

                _operationRepository.Commit();
            }

            operation = Mapper.Map<Operation, OperationViewModel>(_operationDb);

            return new NoContentResult();
        }

        [HttpDelete("{id}", Name = "RemoveOperation")]
        public IActionResult Delete(int id)
        {
            Operation _operationDb = _operationRepository.GetSingle(id);

            if (_operationDb == null)
            {
                return new NotFoundResult();
            }
            else
            {
                _operationRepository.Delete(_operationDb);

                _operationRepository.Commit();

                return new NoContentResult();
            }
        }
    }
}

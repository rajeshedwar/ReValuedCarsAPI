using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReValuedCarsAPI.Models;
using ReValuedCarsAPI.Repositories;

namespace ReValuedCarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReValuedCarsController : ControllerBase
    {
        private IReValuedCarsRepository repo;
        public ReValuedCarsController(IReValuedCarsRepository repository)
        {
            this.repo = repository;
        }

        [HttpGet("Makes", Name = "GetMakes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Make>> GetMakes()
        {
            return repo.GetMake().ToList();
        }

        [HttpGet("Models/{id}", Name = "GetModels")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Model>> GetModels([FromRoute] int id)
        {
            return repo.GetModel(id).ToList();
        }

        [HttpGet("FuelTypes", Name = "GetFuelTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<FuelType>> GetFuelTypes()
        {
            return repo.GetFuelType().ToList();
        }

        [HttpGet("OwnerTypes", Name = "GetOwnerTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<OwnerType>> GetOwnerTypes()
        {
            return repo.GetOwnerType().ToList();
        }

        [HttpGet("RegistrationTypes", Name = "GetRegistrationTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<RegistrationType>> GetRegistrationTypes()
        {
            return repo.GetRegistrationType().ToList();
        }

        [HttpGet("InsuranceTypes", Name = "GetInsuranceTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<InsuranceType>> GetInsuranceTypes()
        {
            return repo.GetInsuranceType().ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReValuedCarsAPI.Helpers;
using ReValuedCarsAPI.Models;
using ReValuedCarsAPI.Repositories;

namespace ReValuedCarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReValuedCarsController : ControllerBase
    {
        private IReValuedCarsRepository repo;
        private IConfiguration configuration;
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };
        private readonly IHostingEnvironment host;
        public ReValuedCarsController(IReValuedCarsRepository repository, IConfiguration config, IHostingEnvironment host)
        {
            this.repo = repository;
            this.configuration = config;
            this.host = host;
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

        [HttpGet("Cars", Name = "GetCars")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CarDetails>> GetCars()
        {
            return repo.GetCars().ToList();
        }

        [HttpGet("Cars/{id}", Name = "GetCar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CarDetails> GetCar([FromRoute] int id)
        {
            var item = repo.GetCar(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpPost("Cars", Name = "AddCar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cars>> AddCarAsync([FromBody]Cars car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await repo.AddCarAsync(car);
            return CreatedAtAction(nameof(GetCar), new { id = result.Id }, result);
        }

        [HttpPut("Cars", Name = "UpdateCar")]
        public async Task<IActionResult> UpdatePost([FromBody]Cars car)
        {
            if (ModelState.IsValid)
            {
                await repo.UpdateCarAsync(car);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("Cars", Name = "DeleteCar")]
        public async Task<IActionResult> DeleteCarAsync([FromRoute]int Id)
        {
            var result = await repo.DeleteCarAsync(Id);
            return CreatedAtAction("", result);
        }

        [HttpPost("CarImage", Name = "AddCarImages")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CarImages>> AddCarImagesAsync(IFormFile filesData, int carId)
        {
            if (filesData == null) return BadRequest("Null File");
            if (filesData.Length == 0)
            {
                return BadRequest("Empty File");
            }
            if (filesData.Length > 10 * 1024 * 1024) return BadRequest("Max file size exceeded.");
            if (!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(filesData.FileName).ToLower())) return BadRequest("Invalid file type.");
            var uploadFilesPath = Path.Combine(host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadFilesPath))
                Directory.CreateDirectory(uploadFilesPath);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(filesData.FileName);
            var filePath = Path.Combine(uploadFilesPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await filesData.CopyToAsync(stream);
            }
            string imageUrl = await AddCarImages(filesData);

            CarImages carImages = new CarImages() { CarID = carId, Url = imageUrl };

            var result = await repo.AddCarImageAsync(carImages);
            return Ok(result);
        }

        [HttpGet("CarImage/{id}", Name = "GetCarImages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CarImages> GetCarImages([FromRoute] int id)
        {
            var item = repo.GetCarImages(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpPost("ViewedCar", Name = "AddViewedCars")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ViewedCars>> AddViewedCarAsync([FromBody]ViewedCars viewedCars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await repo.AddViewedCarAsync(viewedCars);

            return Ok(result);
        }

        private async Task<string> AddCarImages(IFormFile Image)
        {
            string imageUrl = "";
            if (ModelState.IsValid)
            {
                var filePath = Path.GetTempFileName();
                if (Image.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }
                    var dirPath = Path.GetDirectoryName(filePath);
                    var newFilePath = Path.Combine(dirPath, $"{ Guid.NewGuid()}_{Image.FileName}");
                    System.IO.File.Move(filePath, newFilePath);
                    StorageHelper.StorageConnectionString = configuration.GetConnectionString("BlobStorageConnection");
                    imageUrl = await StorageHelper.SaveFileAsync(newFilePath, "images");
                    System.IO.File.Delete(newFilePath);
                }
            }
            return imageUrl;
        }
    }
}
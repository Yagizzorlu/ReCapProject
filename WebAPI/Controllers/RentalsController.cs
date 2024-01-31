using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
            IRentalService _rentalService;

            public RentalsController(IRentalService rentalService)
            {
                _rentalService = rentalService;
            }

            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var result = _rentalService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpGet("getbyid")]
            public IActionResult GetById(int rentalId)
            {
                var result = _rentalService.GetById(rentalId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("add")]
            public IActionResult Add(Rental rental)
            {
                var result = _rentalService.Add(rental);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("update")]
            public IActionResult Update(Rental rental)
            {
                var result = _rentalService.Update(rental);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("delete")]
            public IActionResult Delete(Rental rental)
            {
                var result = _rentalService.Delete(rental);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpGet("getallrentaldetails")]
            public IActionResult GetAllRentalDetails()
            {
                var result = _rentalService.GetAllRentalDetails();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpGet("getrentaldetailsbyid")]
            public IActionResult GetAllRentalDetailsById(int rentalId)
            {
                var result = _rentalService.GetAllRentalDetailsById(rentalId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpGet("getallrentaldetailsbycarid")]
            public IActionResult GetAllRentalDetailsByCarId(int carId)
            {
                var result = _rentalService.GetAllRentalDetailsByCarId(carId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpGet("getallrentaldetailsbycustomerid")]
            public IActionResult GetAllRentalDetailsByCustomerId(int customerId)
            {
                var result = _rentalService.GetAllRentalDetailsByCustomerId(customerId);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
        }
}

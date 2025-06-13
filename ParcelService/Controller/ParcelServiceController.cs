using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelService.DTO;
using ParcelService.Services;

namespace ParcelService.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelServiceController : ControllerBase
    {
        private readonly IParcelService _parcelService;

        public ParcelServiceController(IParcelService parcelService)
        {
            _parcelService = parcelService;

        }
        [HttpGet("getparcels")]
        public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 3)
        {
            var res = await _parcelService.GetAllParcels(pageNumber, pageSize);
            return Ok(res);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetParcel(int id)
        {
            var result = await _parcelService.GetParcelBYID(id);
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> create([FromBody] CreateParcelDTO parcel)
        {
            var res = await _parcelService.createparcel(parcel);
            return CreatedAtAction(nameof(GetParcel), new { id = res.ParcelId }, res);

        }
        [HttpPut("update/{trackingnumber}")]
        public async Task<IActionResult> update(string trackingNumber, UpdateParcelDTO parcel)
        {
            await _parcelService.updateparcel(trackingNumber, parcel);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            await _parcelService.deleteparcel(id);
            return Ok(new { message = "Parcel deleted successfully." });
            //return NoContent();
        }
    }
}

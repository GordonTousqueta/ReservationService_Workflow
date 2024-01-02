using Microsoft.AspNetCore.Mvc;
using ReservationService.Datas.Repository;
using System.Net;

namespace ReservationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly ILogger<UserController> _logger;
        private readonly IReservationRepository _reservationRepository;
        public UserController(ILogger<UserController> logger, IReservationRepository reservationRepository)
        {
            _logger = logger;
            reservationRepository = _reservationRepository;
        }

        [HttpGet("{testAsync}")]
        public async Task<ActionResult> testAsync()
        {
            var test = await _reservationRepository.GetReservationAsync();
            return Ok(test);
        }



    }
}

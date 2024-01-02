using Microsoft.AspNetCore.Mvc;
using ReservationService.Datas.Repository;
using System.Net;

namespace ReservationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {

        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationRepository _reservationRepository;
        public ReservationController(ILogger<ReservationController> logger, IReservationRepository reservationRepository)
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



        /*[Route("CheckId/{id}")]
        [HttpGet]
        public HttpResponseMessage CheckId(int id)
        {
            if (id < 10) // No error hanbdling at all:
            {
                int a = 1;
                int b = 0;
                int c = 0;
                c = a / b; //it would cause exception.
            }
            else if (id < 20) // Error handling by HttpResponseException with HttpStatusCode
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else if (id < 30) // Error handling by HttpResponseException with HttpResponseMessage
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("No Employee found with ID = {0}", 10)),
                    ReasonPhrase = "Employee Not Found"
                };

                throw new HttpResponseException(response);
            }

            return Ok(id);
        }
        public IActionResult Index()
        {
            return View();
        }*/
    }
}

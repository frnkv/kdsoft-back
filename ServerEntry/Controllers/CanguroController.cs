using Domain.APIRequests.Canguros;
using Domain.APIResponses.Canguros;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Canguros;

namespace CircoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CanguroController : ControllerBase
    {

        private readonly ICanguroService _canguroService;

        public CanguroController(ICanguroService canguroService)
        {
            _canguroService = canguroService ?? throw new ArgumentNullException(nameof(canguroService));
        }

        [HttpPost("showEncuentroDeCanguros")]
        public EncuentroCanguroAPIResponse Post_EncuentroDeCanguros(EncuentroCanguroAPIRequest request)
        {
            return _canguroService.ShowEncuentroDeCanguros(request);
        }
    }
}
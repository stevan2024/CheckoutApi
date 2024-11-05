using Microsoft.AspNetCore.Mvc;
using CheckoutApi.Repository;

namespace CheckoutApi.Controllers
{
    /// <summary>
    /// Api controller class which exposes price rules information to web front end.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PriceRulesController : Controller
    {

        private IPricingRulesRepository _pricingRulesRepository;

        public PriceRulesController(IPricingRulesRepository pricingRulesRepository)
        {

            _pricingRulesRepository = pricingRulesRepository;
        }


        [HttpGet()]
        public IActionResult GetPricingRules()
        {
            var items = _pricingRulesRepository.GetPricingRules();
            return Ok(items);
        }
    }
}

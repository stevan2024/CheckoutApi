using CheckoutApi.Models;
using CheckoutApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutApi.Controllers
{

    /// <summary>
    /// Api controller class which exposes the checkout functions to the web front end.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : Controller
    {
        ICheckout _checkout;

        public CheckoutController(ICheckout checkout)
        {

            _checkout = checkout;
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetItems()
        {

            var items = await _checkout.GetAllItems();
            return Ok(items);
        }

        [HttpGet("totals")]
        public IActionResult GetTotals()
        {

            var items = _checkout.GetTotals();
            return Ok(items);
        }

        [HttpPost("scan/{itemId}")]
        public IActionResult Scan(string itemId)
        {

            var total = _checkout.Scan(itemId);
            return Created();
        }

        [HttpPost("price/{itemIds}")]
        public IActionResult Price(string itemIds)
        {

            var total = _checkout.Price(itemIds);
            return Created();
        }


        [HttpDelete("removeItem/{itemId}")]
        public IActionResult RemoveItem(string itemId)
        {
            var total = _checkout.RemoveItem(itemId);
            return Ok(total);
        }

        [HttpDelete("removeAllItems")]
        public IActionResult RemoveAllItems()
        {
            _checkout.RemoveAllItems();
            return Ok();
        }

    }
}

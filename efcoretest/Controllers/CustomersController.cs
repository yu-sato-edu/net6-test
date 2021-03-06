using efcoretest.Models;
using Microsoft.AspNetCore.Mvc;

namespace efcoretest.Controllers;

[Route("api/customers")]
public class CustomersController : Controller
{
    private ICustomerRepository _repository;

    public CustomersController(ICustomerRepository repository)
    {
        _repository = repository;
    }

    [Route(""), HttpGet]
    public IActionResult Get(int offset = 0, int limit = 20)
    {
        return Ok(_repository.GetAll(offset, limit));
    }

    [Route("{CustomerID}"), HttpGet]
    public IActionResult Find(string CustomerID)
    {
        var customer = _repository.Find(CustomerID);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }
}